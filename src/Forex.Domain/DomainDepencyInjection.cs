using Forex.Domain.Factories;
using Forex.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Forex.Domain
{
    public static class DomainDepencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IForexHttpClientFactory, ForexHttpClientFactory>();
            services.AddScoped<IForexService, ForexService>();
        }
    }
}
