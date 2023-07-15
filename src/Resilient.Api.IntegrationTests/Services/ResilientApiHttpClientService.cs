using Web.Common.ChaosMonkey.Services;
using Web.Common.RestHttpClient;
using Web.Common.RestHttpClient.Services;

namespace Resilient.Api.IntegrationTests.Services;

internal sealed class ResilientApiHttpClientService : RestHttpClientService, IRestHttpClientService
{
    public const string ResilientApi = "ResilientApi";

    public HttpClientName HttpClientName => HttpClientName.ResilientApi;

    public ResilientApiHttpClientService(HttpClient httpClient)
        : base(httpClient, new NullChaosService())
    {
    }
}
