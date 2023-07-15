using Microsoft.Extensions.DependencyInjection;
using Resilient.Api.IntegrationTests.Factories;
using Resilient.Api.IntegrationTests.Services;
using Web.Common.RestHttpClient.Factories;
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

    private IResilientApiClientService CreateClientService(HttpClient resilientApiHttpClient)
    {
        //var scope = ServiceProvider.CreateScope();

        //var restHttpClientFactory = ServiceProvider.GetRequiredService<IRestHttpClientFactory>();
        
        var resilientApiHttpClientService = new ResilientApiHttpClientService(resilientApiHttpClient);

        return new ResilientApiClientService(resilientApiHttpClientService);
    }

    public void Dispose()
    { 
        _resilientApiServerFactory.Dispose();
    }
}
