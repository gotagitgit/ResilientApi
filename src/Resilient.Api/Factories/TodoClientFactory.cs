using Microsoft.Extensions.Options;
using Resilient.Api.Settings;
using Web.Common.Services;

namespace Resilient.Api.Factories;

internal sealed class TodoClientFactory : IDisposable, ITodoClientFactory
{
    public const string TodosHttpClientName = "TodosHttpClientName";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptions<TodoApiSetting> _options;
    private HttpClient _httpClient;

    public TodoClientFactory(IHttpClientFactory httpClientFactory, IOptions<TodoApiSetting> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
    }

    public IRestHttpClientService CreateClient()
    {
        _httpClient = _httpClientFactory.CreateClient(TodosHttpClientName);

        _httpClient.BaseAddress = new Uri(_options.Value.BaseUrl);

        return new RestHttpClientService(_httpClient);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
