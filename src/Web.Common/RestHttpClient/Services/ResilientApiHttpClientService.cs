using Web.Common.ChaosMonkey.Services;

namespace Web.Common.RestHttpClient.Services;

internal sealed class ResilientApiHttpClientService : RestHttpClientService, IRestHttpClientService
{
    public const string ResilientApi = "ResilientApi";

    public HttpClientName HttpClientName => HttpClientName.ResilientApi;

    public ResilientApiHttpClientService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory.CreateClient(ResilientApi), new NullChaosService())
    {            
    }
}
