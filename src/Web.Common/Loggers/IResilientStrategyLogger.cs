using Polly;

namespace Web.Common.Loggers;

public interface IResilientStrategyLogger
{
    void LogRetry(DelegateResult<HttpResponseMessage> result, TimeSpan timeSpan, int retryNumber, Context context);
}