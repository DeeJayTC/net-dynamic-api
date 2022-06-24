using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.SQL
{
    public static class ServiceExtension
    {
        public class ProviderConfig : IDatabaseProviderConfiguration
        {
            private IConfiguration configuration;
            public ProviderConfig(IConfiguration config)
            {
                this.configuration = config;
            }
            
            public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("ApiGeneratorDatabase"));
            }
        }

        private static ApiGeneratorServiceBuilder AddDataContextSQLite(this ApiGeneratorServiceBuilder builder)
        {
            if (builder.ApiGeneratorConfig.DatabaseOptions.Connection == null)
            {
                throw new ArgumentException("Provide a connection string in configuration before initiating Database");
            }

            builder.Services.AddDbContext<GenericDbContext>(options =>
            {
                options.UseSqlite(connectionString: builder.ApiGeneratorConfig.DatabaseOptions.Connection, b =>
                {
                    if (builder.ApiGeneratorConfig.DatabaseOptions.EnableAutomaticMigration)
                    {
                        b.MigrationsAssembly(builder.ApiGeneratorConfig.DatabaseOptions.MigrationAssembly);
                    }
                });

            });


            builder.Services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlite(connectionString: builder.ApiGeneratorConfig.DatabaseOptions.Connection, b =>
                {
                    if (builder.ApiGeneratorConfig.DatabaseOptions.EnableAutomaticMigration)
                    {
                        b.MigrationsAssembly(builder.ApiGeneratorConfig.DatabaseOptions.MigrationAssembly);
                    }
                });

            });

            builder.Services.AddSingleton<IDatabaseProviderConfiguration, ProviderConfig>();
            return builder;

        }

    }
}