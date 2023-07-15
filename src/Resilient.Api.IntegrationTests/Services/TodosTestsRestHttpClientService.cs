using Resilient.Api.Services;
using Web.Common.ChaosMonkey.Services;
using Web.Common.RestHttpClient;
using Web.Common.RestHttpClient.Services;

namespace Resilient.Api.IntegrationTests.Services;
internal class TodosTestsRestHttpClientService : RestHttpClientService, IRestHttpClientService
{
    public HttpClientName HttpClientName => HttpClientName.TodoApi;

    public TodosTestsRestHttpClientService(IHttpClientFactory httpClientFactory, IChaosService chaosService)
        : base(httpClientFactory.CreateClient(TodosApiRestHttpClientService.TodosApi), chaosService)
    {
    }
}
