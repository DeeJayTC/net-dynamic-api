using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TCDev.APIGenerator.Data;

namespace TCDev.APIGenerator.Extension
{
    public static class ServiceExtension
    {

        private static ApiGeneratorServiceBuilder AddDataContextSQL(
            this ApiGeneratorServiceBuilder builder)
        {
            if(builder.ApiGeneratorConfig.DatabaseOptions.Connection == null)
            {
                throw new ArgumentException("Provide a connection string in configuration before initiating Database");
            }

            builder.Services.AddDbContext<GenericDbContext>(options =>
            {
                options.UseSqlServer(connectionString: builder.ApiGeneratorConfig.DatabaseOptions.Connection, b =>
                {
                    if (builder.ApiGeneratorConfig.DatabaseOptions.EnableAutomaticMigration)
                    {
                        b.MigrationsAssembly(builder.ApiGeneratorConfig.DatabaseOptions.MigrationAssembly);
                    }
                });

            });
           return builder;
        }
    }
}