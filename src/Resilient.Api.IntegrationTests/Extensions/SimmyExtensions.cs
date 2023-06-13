using Polly;
using Polly.Contrib.Simmy;
using Polly.Registry;

namespace Resilient.Api.IntegrationTests.Extensions;

internal static class HttpRequestChaosPolicy
{
    private static readonly Task<bool> NotEnabled = Task.FromResult(false);
    private static readonly Task<Exception> NoExceptionResult = Task.FromResult<Exception>(null);
    private static readonly Task<double> NoInjectionRate = Task.FromResult<double>(0);

    public static IPolicyRegistry<string> AddHttpChaosInjectors(this IPolicyRegistry<string> registry)
    {
        foreach (var policyEntry in registry)
        {
            if (policyEntry.Value is IAsyncPolicy<HttpResponseMessage> policy)
            {
                registry[policyEntry.Key] = policy
                        .WrapAsync(MonkeyPolicy.InjectFaultAsync<HttpResponseMessage>(
                            GetException,
                            GetInjectionRate,
                            GetEnabled));
            }
        }

        return registry;
    }

    private static Task<double> GetInjectionRate(Context context, CancellationToken ct)
    {
        var chaosSettings = context.GetOperationChaosSettings();
        if (chaosSettings == null) return NoInjectionRate;

        return Task.FromResult(chaosSettings.InjectionRate);
    }

    private static Task<Exception> GetException(Context context, CancellationToken token)
    {
        var chaosSettings = context.GetOperationChaosSettings();
        if (chaosSettings == null) return NoExceptionResult;

        string exceptionName = chaosSettings.Exception;
        if (string.IsNullOrWhiteSpace(exceptionName)) return NoExceptionResult;

        try
        {
            Type exceptionType = Type.GetType(exceptionName);
            if (exceptionType == null) return NoExceptionResult;

            if (!typeof(Exception).IsAssignableFrom(exceptionType)) return NoExceptionResult;

            var instance = Activator.CreateInstance(exceptionType);
            return Task.FromResult(instance as Exception);
        }
        catch
        {
            return NoExceptionResult;
        }
    }

    private static Task<bool> GetEnabled(Context context, CancellationToken ct)
    {
        var chaosSettings = context.GetOperationChaosSettings();
        if (chaosSettings == null) return NotEnabled;

        return Task.FromResult(chaosSettings.Enabled);
    }
}
