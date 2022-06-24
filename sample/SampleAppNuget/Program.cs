using System.Configuration;
using System.Reflection;
using TCDev.APIGenerator;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Identity;
using TCDev.APIGenerator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiGeneratorIdentity(builder.Configuration);

builder.Services.AddApiGeneratorServices()
                .AddAssemblyWithOData(Assembly.GetExecutingAssembly())
                .AddDataContextSQL()
                .AddOData()
                .AddSwagger(true);


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseApiGenerator();
app.UseAutomaticApiMigrations(false);

app.MapControllers();

app.Run();
