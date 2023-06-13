using Divergic.Logging.Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
namespace Resilient.Api.IntegrationTests.Factories;

public sealed class ResilientApiServerFactory : WebApplicationFactory<Program>
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ResilientApiServerFactory(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddLogging(x => x.AddXunit(_testOutputHelper, new LoggingConfig { LogLevel = LogLevel.Debug }));
        });

        builder.ConfigureTestServices(services =>
        {
            //services.AddScoped<IMongoDbContext, DbContextFixture>();

            //services.Configure<DatabaseSettings>(x => x.DatabaseName = $"inventory_test_db_{Guid.NewGuid()}");           
            
        });

        //var policyRegistry = base.Server.Services.GetRequiredService<IPolicyRegistry<string>>();

        //policyRegistry?.AddHttpChaosInjectors();

        base.ConfigureWebHost(builder);
    }
}
