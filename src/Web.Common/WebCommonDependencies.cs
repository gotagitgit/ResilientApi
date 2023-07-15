using Microsoft.Extensions.DependencyInjection;
using Web.Common.ChaosMonkey.Services;
using Web.Common.RestHttpClient.Factories;

namespace Web.Common;

public static class WebCommonDependencies
{
    public static IServiceCollection RegisterWebCommonDependencies(this IServiceCollection services)
    {
        services.AddScoped<IChaosService, InjectChaosService>();

        services.AddScoped<IRestHttpClientFactory, RestHttpClientFactory>();

        return services;
    }
}
