using Forex.Domain.Factories;

namespace ResilientApi.ConfigSetup
{
    public sealed class MvcSetup : IConfigSetup
    {
        public void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            AddHttpClient(services);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        private static void AddHttpClient(IServiceCollection services)
        {
            _ = services.AddHttpClient(ForexHttpClient.ForexHttpClientName)
                        .ConfigurePrimaryHttpMessageHandler(() =>
                        {
                            return new HttpClientHandler
                            {
                                AllowAutoRedirect = true,
                            };
                        });
        }
    }
}
