using Web.Common.Services;

namespace Resilient.Api.Factories;

internal sealed class TodoClientFactory : IDisposable, ITodoClientFactory
{
    public const string TodosHttpClientName = "TodosHttpClientName";

    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient _httpClient;

    public TodoClientFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IRestHttpClientService CreateClient()
    {
        _httpClient = _httpClientFactory.CreateClient(TodosHttpClientName);

        return new RestHttpClientService(_httpClient);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
