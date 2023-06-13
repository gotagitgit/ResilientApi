using Microsoft.Extensions.Options;
using Web.Common.Services;
using Web.Common.Simmy.Settings;

namespace Resilient.Api.Factories;

internal sealed class TodoClientFactory : IDisposable, ITodoClientFactory
{
    public const string TodosHttpClientName = "TodosHttpClientName";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ChaosSettings _chaosSettings;
    private HttpClient _httpClient;

    public TodoClientFactory(IHttpClientFactory httpClientFactory, IOptions<ChaosSettings> chaosSettings)
    {
        _httpClientFactory = httpClientFactory;
        _chaosSettings = chaosSettings.Value;
    }

    public IRestHttpClientService CreateClient()
    {
        _httpClient = _httpClientFactory.CreateClient(TodosHttpClientName);

        return new RestHttpClientService(_httpClient, _chaosSettings);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
