using Microsoft.Extensions.Logging;
using Polly;

namespace Resilient.Api.IntegrationTests.Loggers;
internal class TestResilientStrategyLogger : ITestResilientStrategyLogger
{
    private readonly ILogger<TestResilientStrategyLogger> _logger;

    public TestResilientStrategyLogger(ILogger<TestResilientStrategyLogger> logger)
    {
        _logger = logger;
    }

    public int RetryCount { get; private set; }

    public void LogRetry(DelegateResult<HttpResponseMessage> result, TimeSpan timeSpan, int retryNumber, Context context)
    {
        RetryCount = retryNumber;

        _logger.LogInformation($"Test logger count retry {retryNumber}");
    }
}
