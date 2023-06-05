using Microsoft.Extensions.Options;
using Web.Common.Settings;

namespace Resilient.Domain.Factories;

internal sealed class TodoClientFactory
{
    public const string TodosHttpClientName = "TodosHttpClient";

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptions<TodoApiSetting> _options;

    public TodoClientFactory(IHttpClientFactory httpClientFactory, IOptions<TodoApiSetting> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
    }

    public HttpClient CreateHttpClient()
    {
        var httpClient = _httpClientFactory.CreateClient(TodosHttpClientName);

        httpClient.BaseAddress = new Uri(_options.Value.BaseUrl);

        return httpClient;
    }
}
