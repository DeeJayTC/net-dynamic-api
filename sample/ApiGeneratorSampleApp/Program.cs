using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TCDev.APIGenerator;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Identity;
using TCDev.APIGenerator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiGeneratorIdentity(builder.Configuration);

builder.Services.AddApiGeneratorServices()
                .AddAssemblyWithOData(Assembly.GetExecutingAssembly())
                .AddDataContextSQL()
                .AddOData()
                //.AddRedisCache()
                //.AddRabbitMQ()
                .AddSwagger(true);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseApiGenerator();
app.UseAutomaticApiMigrations(true);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseApiGeneratorAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.UseApiGeneratorEndpoints();
    endpoints.MapControllers();
});

app.Run();
