using Polly.Registry;
using Resilient.Api;
using Resilient.Api.Extensions;
using Resilient.Api.Settings;
using Serilog;
using Web.Common.Simmy.Extensions;
using Web.Common.Simmy.Settings;

var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

Log.Logger = logger;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Host.UseSerilog(logger);

var programLogger = LoggerFactory.Create(x => x.AddSerilog(logger)).CreateLogger(nameof(Program));

var services = builder.Services;

services.Configure<TodoApiSetting>(builder.Configuration.GetSection(nameof(TodoApiSetting)));
services.Configure<ChaosSettings>(builder.Configuration.GetSection(nameof(ChaosSettings)));

services.RegisterApiDependencies()
        .AddResilientStrategies(builder.Configuration, programLogger);

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    var policyRegistry = app.Services.GetRequiredService<IPolicyRegistry<string>>();
    policyRegistry?.AddHttpChaosInjectors();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }



