using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Resilient.Api.IntegrationTests.Fixtures;
using Resilient.Api.IntegrationTests.Loggers;
using Resilient.Api.IntegrationTests.Services;
using Web.Common.Loggers;
using Web.Common.Simmy.Settings;
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
        EnableChaosSetting("Status");

        // Act
        var result = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _resilientApiClient.GetAsync());

        // Assert
        var scope = _context.ServiceProvider.CreateScope();

        var logger = scope.ServiceProvider.GetRequiredService<IResilientStrategyLogger>();

        if (logger is ITestResilientStrategyLogger testLogger)
        {
            testLogger.RetryCount.Should().Be(5);
        }
    }

    private void EnableChaosSetting(string key)
    {
        var chaosSettings = _context.ServiceProvider.GetRequiredService<IOptions<ChaosSettings>>();

        var operationChaosSetting = chaosSettings.Value.OperationChaosSettings.First(x => x.OperationKey == key);

        operationChaosSetting.Enabled = true;
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