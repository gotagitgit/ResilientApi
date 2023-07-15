using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Registry;
using Resilient.Api.IntegrationTests.Extensions;
using Resilient.Api.IntegrationTests.Fixtures;
using Resilient.Api.IntegrationTests.Services;
using Xunit.Abstractions;

namespace Resilient.Api.IntegrationTests;

public class TodosTests
{
    private readonly TestContext _context;
    private readonly IResilientApiClientService _resilientApiClient;
    
    public TodosTests(ITestOutputHelper testOutputHelper)
    {
        _context = new TestContext(testOutputHelper);

        _resilientApiClient = _context.ResilientApiClient;
    }

    [Fact]
    public async Task Should_get_todos()
    {
        // Arrange
        //var policyRegistry = _context.ServiceProvider.GetRequiredService<IPolicyRegistry<string>>();

        //policyRegistry?.AddHttpChaosInjectors();

        // Act
        var result = await _resilientApiClient.GetAsync();
    }

    public sealed class TestContext : IDisposable
    {
        private readonly ResilientApiFixture _inventoryFixture;

        public TestContext(ITestOutputHelper testOutputHelper)
        {
            _inventoryFixture = new ResilientApiFixture(testOutputHelper);

            ResilientApiClient = _inventoryFixture.ResilientApiClientServices;

            ServiceProvider = _inventoryFixture.ServiceProvider;
        }

        public IResilientApiClientService ResilientApiClient { get; }

        public IServiceProvider ServiceProvider { get; }

        public void Dispose()
        {
            _inventoryFixture.Dispose();
        }
    }
}