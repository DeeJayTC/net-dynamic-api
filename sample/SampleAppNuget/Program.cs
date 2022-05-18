using System.Configuration;
using System.Reflection;
using TCDev.APIGenerator.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddApiGeneratorServices(builder.Configuration, Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseApiGenerator();
app.MapControllers();

app.Run();
