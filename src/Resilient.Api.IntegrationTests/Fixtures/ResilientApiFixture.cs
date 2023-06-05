using Resilient.Api.IntegrationTests.Factories;
using Resilient.Api.IntegrationTests.Services;
using Web.Common.Services;
using Xunit.Abstractions;

namespace Resilient.Api.IntegrationTests.Fixtures;

internal class ResilientApiFixture : IDisposable
{
    private readonly ResilientApiServerFactory _resilientApiServerFactory;

    public ResilientApiFixture(ITestOutputHelper testOutputHelper)
    {
        _resilientApiServerFactory = new ResilientApiServerFactory(testOutputHelper);

        var _resilientApiHttpClient = _resilientApiServerFactory.CreateClient();

        var baseUri = new Uri("https://localhost:7017/api/Todo");

        _resilientApiHttpClient.BaseAddress = baseUri;

        var restHttpClientService = new RestHttpClientService(_resilientApiHttpClient);

        ResilientApiClientServices = new ResilientApiClientService(restHttpClientService);

        ServiceProvider = _resilientApiServerFactory.Server.Services;
    }

    public IResilientApiClientService ResilientApiClientServices { get; }

    public IServiceProvider ServiceProvider { get; }

    public void Dispose()
    {     

        _resilientApiServerFactory.Dispose();
    }
}
