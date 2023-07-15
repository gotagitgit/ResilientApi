using Web.Common.RestHttpClient.Services;

namespace Web.Common.RestHttpClient.Factories;

internal sealed class RestHttpClientFactory : IRestHttpClientFactory
{
    private readonly IDictionary<HttpClientName, IRestHttpClientService> _httpClientServices;

    public RestHttpClientFactory(IEnumerable<IRestHttpClientService> restHttpClientService)
    {
        _httpClientServices = restHttpClientService.ToDictionary(x => x.HttpClientName, x => x);
    }

    public IRestHttpClientService Create(HttpClientName httpClientName)
    {
        if (_httpClientServices.TryGetValue(httpClientName, out var restHttpClientService))
            return restHttpClientService;

        throw new ArgumentException($"There is no implementation of {httpClientName} RestHttpClientService");
    }
}
