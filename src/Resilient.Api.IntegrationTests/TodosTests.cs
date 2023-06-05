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
    public async void Should_get_todos()
    {
        // Arrane

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
        }

        public IResilientApiClientService ResilientApiClient { get; }

        public void Dispose()
        {
            _inventoryFixture.Dispose();
        }
    }
}