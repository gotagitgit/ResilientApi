using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Resilient.Api.IntegrationTests.Factories;
internal class MockProgramLogger : ILogger
{
    private readonly string _categoryName;
    private readonly ITestOutputHelper _testOutputHelper;

    public MockProgramLogger(string categoryName, ITestOutputHelper testOutputHelper)
    {
        _categoryName = categoryName;
        _testOutputHelper = testOutputHelper;
    }

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        _testOutputHelper.WriteLine($"Log from mock {logLevel}: ({_categoryName}) {formatter(state, exception)} {exception}");
    }
}
