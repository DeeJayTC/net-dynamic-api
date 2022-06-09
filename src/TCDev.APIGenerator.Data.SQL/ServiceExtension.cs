using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.Extension
{
    public static partial class ServiceExtension
    {

        public static ApiGeneratorServiceBuilder AddDataContextSQL(
            this ApiGeneratorServiceBuilder builder,
        Action<SqlServerDbContextOptionsBuilder>? sqlOptions = null)
        {
            if(builder.ApiGeneratorConfig.DatabaseOptions.Connection == null)
            {
                throw new ArgumentException("Provide a connection string in configuration before initiating Database");
            }
            try
            {
                builder.Services.AddDbContext<GenericDbContext>(options =>
                {
                    if (sqlOptions != null)
                    {
                        options.UseSqlServer(sqlOptions);
                    }
                    else
                    {
                        options.UseSqlServer(connectionString: builder.ApiGeneratorConfig.DatabaseOptions.Connection, b =>
                        {
                            if (builder.ApiGeneratorConfig.DatabaseOptions.EnableAutomaticMigration)
                            {
                                b.MigrationsAssembly(builder.ApiGeneratorConfig.DatabaseOptions.MigrationAssembly);
                            }
                        });
                    }


                });



                builder.Services.AddDbContext<AuthDbContext>(options =>
                {
                    if (sqlOptions != null)
                    {
                        options.UseSqlServer(sqlOptions);
                    }
                    else
                    {
                        options.UseSqlServer(connectionString: builder.ApiGeneratorConfig.DatabaseOptions.Connection, b =>
                        {
                            if (builder.ApiGeneratorConfig.DatabaseOptions.EnableAutomaticMigration)
                            {
                                b.MigrationsAssembly(builder.ApiGeneratorConfig.DatabaseOptions.MigrationAssembly);
                            }
                        });
                    }


                });
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Could not add the Database connection, make sure your connection string is correct.");
            }


            builder.Services.AddSingleton<IDatabaseProviderConfiguration, ProviderConfig>();
            return builder;
        }
    }
}