using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Resilient.Api.IntegrationTests.Fixtures;
using Resilient.Api.IntegrationTests.Loggers;
using Resilient.Api.IntegrationTests.Services;
using Web.Common.Loggers;
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
    public async Task Should_retry_on_fail()
    {
        // Arrange

        // Act
        var result = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _resilientApiClient.GetAsync());

        // Assert

        var scope = _context.ServiceProvider.CreateScope();

        var logger = scope.ServiceProvider.GetRequiredService<IResilientStrategyLogger>();

        if (logger is ITestResilientStrategyLogger testLogger)
        {
            testLogger.RetryCount.Should().BeGreaterThan(0);
        }
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