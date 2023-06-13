using Polly;
using Polly.Extensions.Http;
using Resilient.Api.Factories;
using Resilient.Api.Settings;

namespace Resilient.Api.Extensions;

public static class ResilientStrategies
{
    public const string HttpResiliencePolicy = "HttpResiliencePolicy";

    public static IServiceCollection AddResilientStrategies(this IServiceCollection services, IConfiguration configuration, ILogger logger)
    {
        var policyRegistry = services.AddPolicyRegistry();

        policyRegistry[HttpResiliencePolicy] = GetResiliencePolicy(configuration, logger);

        services.AddHttpClient(TodoClientFactory.TodosHttpClientName, client =>
        {
            var todoApiSettings = configuration.GetSection(nameof(TodoApiSetting)).Get<TodoApiSetting>();

            client.BaseAddress = new Uri(todoApiSettings.BaseUrl);
        })
        .AddPolicyHandlerFromRegistry(HttpResiliencePolicy);

        return services;
    }

    //private static IAsyncPolicy<HttpResponseMessage> GetResiliencePolicy(IConfiguration configuration)
    //{
    //    var resilienceSettings = configuration.GetSection(nameof(ResilienceSettings)).Get<ResilienceSettings>();

    //    var policies = HttpPolicyExtensions.HandleTransientHttpError()
    //        .RetryAsync(resilienceSettings.RetryCount)
    //        .WrapAsync(HttpPolicyExtensions.HandleTransientHttpError()
    //            .CircuitBreakerAsync(resilienceSettings.ExceptionsAllowedBeforeBreaking, TimeSpan.FromSeconds(5)));

    //    return policies;
    //}

    private static IAsyncPolicy<HttpResponseMessage> GetResiliencePolicy(IConfiguration configuration, ILogger logger)
    {
        // Define a policy which will form our resilience strategy.  These could be anything.  The settings for them could obviously be drawn from config too.
        var retry = HttpPolicyExtensions.HandleTransientHttpError()
            //.RetryAsync(5);
            .WaitAndRetryAsync(5, _ => TimeSpan.FromMilliseconds(500),
                (result, timespan, retryNo, context) =>
                {
                    logger.LogInformation($"{context.OperationKey}: Retry number {retryNo} within " +
                        $"{timespan.TotalMilliseconds}ms. Original status code: 503");
                });

        return retry;
    }

    //private static IAsyncPolicy<HttpResponseMessage> GetResiliencePolicy(IConfiguration configuration)
    //{
    //    var retryCount = 5;

    //    // Define a policy which will form our resilience strategy.  These could be anything.  The settings for them could obviously be drawn from config too.
    //    var retry = HttpPolicyExtensions.HandleTransientHttpError()
    //        //.RetryAsync(5);
    //        .WaitAndRetryAsync(
    //            retryCount,
    //            retryAttempt => TimeSpan.FromSeconds(Math.Pow(1, retryAttempt)),
    //            onRetry: (_, _, retryAttempt, _) =>
    //            {
    //                Console.WriteLine($"Retry attempt ({retryAttempt} of {retryCount})");
    //            });

    //    return retry;
    //}
}
