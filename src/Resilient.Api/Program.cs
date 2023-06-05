using Polly;
using Resilient.Api;
using Resilient.Api.Factories;
using Resilient.Api.Settings;
using Web.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.Configure<TodoApiSetting>(builder.Configuration.GetSection(nameof(TodoApiSetting)));

services.RegisterApiDependencies()
        .RegisterWebCommonDependencies()
        .RegisterTodosHttpClient(builder.Configuration);

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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