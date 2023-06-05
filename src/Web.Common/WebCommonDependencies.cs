using Microsoft.Extensions.DependencyInjection;
using Web.Common.Services;

namespace Web.Common;

public static class WebCommonDependencies
{
    public static IServiceCollection RegisterWebCommonDependencies(this IServiceCollection services)
    {
        services.AddScoped<IRestHttpClientService, RestHttpClientService>();

        return services;
    }
}
