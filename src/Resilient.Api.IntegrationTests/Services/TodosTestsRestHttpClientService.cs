using Web.Common.ChaosMonkey.Services;
using Web.Common.RestHttpClient;
using Web.Common.RestHttpClient.Services;

namespace Resilient.Api.IntegrationTests.Services;
internal class TodosTestsRestHttpClientService : RestHttpClientService, IRestHttpClientService
{
    public const string TodosApi = "TodosApi";

    public HttpClientName HttpClientName => HttpClientName.TodoApi;

    public TodosTestsRestHttpClientService(IHttpClientFactory httpClientFactory, IChaosService chaosService)
        : base(httpClientFactory.CreateClient(TodosApi), chaosService)
    {
    }
}
