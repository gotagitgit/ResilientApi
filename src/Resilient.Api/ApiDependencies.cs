using Resilient.Api.Services;
using Web.Common.Services;

namespace Resilient.Api;

public static class ApiDependencies
{
    public static IServiceCollection RegisterApiDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITodosService, TodosService>();
        services.AddScoped<IRestHttpClientService, RestHttpClientService>();

        return services;
    }
}
