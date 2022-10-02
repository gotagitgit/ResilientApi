using Forex.Domain;

namespace ResilientApi.ConfigSetup
{
    public class DependencySetup : IConfigSetup
    {
        public void Configure(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            DomainDepencyInjection.Configure(services);
        }
    }
}
