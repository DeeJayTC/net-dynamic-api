using System.Configuration;
using System.Reflection;
using TCDev.APIGenerator;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiGeneratorIdentity(builder.Configuration);

builder.Services.AddApiGeneratorServices()
                .AddConfig(new ApiGeneratorConfig()
                {
                    ApiOptions = new ApiOptions()
                    {
                        UseHealthCheck = true
                    },
                    DatabaseOptions = new DatabaseOptions()
                    {
                        Connection = "Server=localhost;database=wdcc;user=sa;password=Password!23;",
                        DatabaseType = DbType.Sql,
                        EnableAutomaticMigration = true
                    }
                })
                .AddAssembly(Assembly.GetExecutingAssembly())
                .AddDataContextSQL()
                .AddOData()
                .AddSwagger();


var app = builder.Build();

app.UseApiGenerator();
app.UseAutomaticApiMigrations(true);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseApiGenerator();
app.MapControllers();

app.Run();
