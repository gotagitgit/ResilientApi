using System.Text;
using System.Text.Json;
using Web.Common.ChaosMonkey.Services;

namespace Web.Common.RestHttpClient.Services;

public class RestHttpClientService 
{   
    private readonly HttpClient _httpClient;
    private readonly IChaosService _chaosService;
    private readonly Uri _baseUri;

    public RestHttpClientService(HttpClient httpClient, IChaosService chaosService)
    {
        _httpClient = httpClient;
        _chaosService = chaosService;
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string routeSuffix, TRequest requestContent)
    {
        var uri = new Uri(_baseUri, routeSuffix);

        var httpContent = Serialize(requestContent);

        var response = await _httpClient.PostAsync(uri, httpContent);

        return await DeserializeRespnseAsync<TResponse>(response);
    }

    public async Task<TResponse> GetAsync<TResponse>(string routeSuffix = "")
    {
        var uri = _baseUri;
        if (!string.IsNullOrWhiteSpace(routeSuffix))
            uri = new Uri(_baseUri, routeSuffix);

        using var request = new HttpRequestMessage(HttpMethod.Get, uri);

        _chaosService.InjectChaosToRequest(request, "Status");

        var response = await _httpClient.SendAsync(request);

        return await DeserializeRespnseAsync<TResponse>(response);
    }

    private static HttpContent Serialize<T>(T value)
    {
        var json = JsonSerializer.Serialize(value);

        return new StringContent(json, Encoding.UTF8, "application/json");
    }

    private static async Task<T> DeserializeRespnseAsync<T>(HttpResponseMessage response)
    {
        EnsureSuccess(response);

        await using var stream = await response.Content.ReadAsStreamAsync();

        return await JsonSerializer.DeserializeAsync<T>(stream);
    }

    private static void EnsureSuccess(HttpResponseMessage response)
    {
        if (response == null || response.IsSuccessStatusCode)
            return;

        var result = response.Content.ReadAsStringAsync().Result;

        var builder = new StringBuilder();

        builder.AppendLine("Http operation unsuccessful");
        builder.AppendLine(string.Format("Status: '{0}'", response.StatusCode));
        builder.AppendLine(string.Format("Reason: '{0}'", response.ReasonPhrase));
        builder.AppendLine(result);

        throw new InvalidOperationException(builder.ToString());
    }
}