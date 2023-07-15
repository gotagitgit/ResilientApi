using Resilient.Api.Loggers;
using Resilient.Api.Services;
using Web.Common.Loggers;
using Web.Common.RestHttpClient.Services;

namespace Resilient.Api;

public static class ApiDependencies
{
    public static IServiceCollection RegisterApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITodosService, TodosService>();
        services.AddScoped<IRestHttpClientService, TodosApiRestHttpClientService>();

        services.AddScoped<IResilientStrategyLogger, ResilientStrategyLogger>();

        return services;
    }
}
