using Resilient.Api.Factories;
using Resilient.Api.Services;

namespace Resilient.Api;

public static class ApiDependencies
{
    public static IServiceCollection RegisterApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITodosService, TodosService>();
        services.AddScoped<ITodoClientFactory, TodoClientFactory>();

        return services;
    }
}
