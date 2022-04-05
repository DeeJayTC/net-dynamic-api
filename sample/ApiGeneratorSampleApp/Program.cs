// TCDev.de 2022/03/16
// ApiGeneratorSampleApI.Program.cs
// https://www.github.com/deejaytc/dotnet-utils

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TCDev.ApiGenerator.Extension;
using TCDev.ApiGenerator.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddApiGeneratorServices(builder.Configuration, JsonClassBuilder.CreateClass());
builder.Services.AddApiGeneratorServices(builder.Configuration, Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseApiGenerator();
app.UseAutomaticApiMigrations(true);

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
   endpoints.UseApiGeneratorEndpoints();
   endpoints.MapControllers();
});

app.Run();
