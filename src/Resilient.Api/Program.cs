using Resilient.Api;
using Resilient.Api.Extensions;
using Resilient.Api.Settings;
using Web.Common;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.Configure<TodoApiSetting>(builder.Configuration.GetSection(nameof(TodoApiSetting)));

services.RegisterApiDependencies()
        .RegisterWebCommonDependencies()
        .AddResilientStrategies(builder.Configuration);

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }