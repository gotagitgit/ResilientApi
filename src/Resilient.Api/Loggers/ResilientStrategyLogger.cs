using Polly;
using Web.Common.Loggers;

namespace Resilient.Api.Loggers;

internal sealed class ResilientStrategyLogger : IResilientStrategyLogger
{
    private readonly ILogger<ResilientStrategyLogger> _logger;

    public ResilientStrategyLogger(ILogger<ResilientStrategyLogger> logger)
    {
        _logger = logger;
    }

    public void LogRetry(DelegateResult<HttpResponseMessage> result, TimeSpan timeSpan, int retryNumber, Context context)
    {
        _logger.LogInformation($"{context.OperationKey}: Retry number {retryNumber} within " +
                    $"{timeSpan.TotalMilliseconds}ms. Original status code: {result.Result.StatusCode}");
    }
}

