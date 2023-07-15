using Resilient.Api.IntegrationTests.Factories;
using Resilient.Api.IntegrationTests.Services;
using Xunit.Abstractions;

namespace Resilient.Api.IntegrationTests.Fixtures;

internal class ResilientApiFixture : IDisposable
{
    private readonly ResilientApiServerFactory _resilientApiServerFactory;

    public ResilientApiFixture(ITestOutputHelper testOutputHelper)
    {
        _resilientApiServerFactory = new ResilientApiServerFactory(testOutputHelper);         

        ServiceProvider = _resilientApiServerFactory.Server.Services;

        var resilientApiHttpClient = _resilientApiServerFactory.CreateClient();

        ResilientApiClientServices = CreateClientService(resilientApiHttpClient);
    }

    public IServiceProvider ServiceProvider { get; }

    public IResilientApiClientService ResilientApiClientServices { get; }

    private static IResilientApiClientService CreateClientService(HttpClient resilientApiHttpClient)
    {
        var resilientApiHttpClientService = new ResilientApiHttpClientService(resilientApiHttpClient);

        return new ResilientApiClientService(resilientApiHttpClientService);
    }

    public void Dispose()
    { 
        _resilientApiServerFactory.Dispose();
    }
}
