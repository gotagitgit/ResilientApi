using Microsoft.OpenApi.Models;

namespace ResilientApi.ConfigSetup
{
    public sealed class SwaggerSetup : IConfigSetup
    {
        public void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Forex",
                    Version = "v1"
                });
            });
        }
    }
}
