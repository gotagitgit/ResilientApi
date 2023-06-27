using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Resilient.Api.IntegrationTests.Factories;
internal class MockLoggerFactory : ILoggerFactory
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ITestOutputHelper? TestOutputHelper { get; set; }

    public MockLoggerFactory(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    public void Dispose()
    {
        TestOutputHelper = null;
    }

    public void AddProvider(ILoggerProvider provider)
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new MockProgramLogger(categoryName, _testOutputHelper);
    }
}
