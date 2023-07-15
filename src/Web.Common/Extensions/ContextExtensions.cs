using Polly;
using Web.Common.Loggers;

namespace Web.Common.Extensions;

public static class ContextExtensions
{
    private static readonly string LoggerKey = "ResilientApiLogger";

    public static Context WithLogger(this Context context, IResilientStrategyLogger logger)
    {
        context[LoggerKey] = logger;

        return context;
    }

    public static IResilientStrategyLogger GetLogger(this Context context)
    {
        if (context.TryGetValue(LoggerKey, out object logger))
        {
            return logger as IResilientStrategyLogger;
        }
        return null;
    }
}