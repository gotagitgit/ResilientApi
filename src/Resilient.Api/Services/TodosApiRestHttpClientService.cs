using Web.Common.ChaosMonkey.Services;
using Web.Common.RestHttpClient;
using Web.Common.RestHttpClient.Services;

namespace Resilient.Api.Services;

public sealed class TodosApiRestHttpClientService : RestHttpClientService, IRestHttpClientService
{
    public const string TodosApi = "TodosApi";

    public HttpClientName HttpClientName => HttpClientName.TodoApi;

    public TodosApiRestHttpClientService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory.CreateClient(TodosApi), new NullChaosService())
    {
    }
}
