using Polly;
using Resilient.Api.Factories;

namespace Resilient.Api.Settings;

public static class HttpClientSettings
{
    public static IServiceCollection RegisterTodosHttpClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient(TodoClientFactory.TodosHttpClientName, client =>
        {
            var todoApiSettings = configuration.GetSection(nameof(TodoApiSetting)).Get<TodoApiSetting>();

            client.BaseAddress = new Uri(todoApiSettings.BaseUrl);
        })
        .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10)
        }));

        return services;
    }
}
