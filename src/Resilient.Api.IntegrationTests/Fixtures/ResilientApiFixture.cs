﻿using Microsoft.Extensions.DependencyInjection;
using Resilient.Api.Factories;
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

        var _resilientApiHttpClient = _resilientApiServerFactory.CreateClient();

        var baseUri = new Uri("https://localhost:7017/api/Todo");

        _resilientApiHttpClient.BaseAddress = baseUri;

        ServiceProvider = _resilientApiServerFactory.Server.Services;

        ResilientApiClientServices = CreateClientService();
    }

    public IServiceProvider ServiceProvider { get; }

    public IResilientApiClientService ResilientApiClientServices { get; }

    private IResilientApiClientService CreateClientService()
    {
        var todoClientFactory = ServiceProvider.GetRequiredService<ITodoClientFactory>();

        var restHttpClientService = todoClientFactory.CreateClient();

        return new ResilientApiClientService(restHttpClientService);
    }

    public void Dispose()
    { 
        _resilientApiServerFactory.Dispose();
    }
}
