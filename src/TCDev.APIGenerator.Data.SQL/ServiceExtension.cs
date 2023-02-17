using EFCore.AutomaticMigrations;
using Microsoft.AspNetCore.Builder;
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

        public static IApplicationBuilder UseAutomaticApiMigrations(
            this IApplicationBuilder app,
            bool allowDataLoss = false)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var builder = serviceScope.ServiceProvider.GetRequiredService<ApiGeneratorServiceBuilder>();

            var dbContext = serviceScope.ServiceProvider.GetService<GenericDbContext>();
            if (builder.ApiGeneratorConfig.DatabaseOptions.DatabaseType != DbType.InMemory)
            {
                try
                {
                    dbContext.MigrateToLatestVersion(new DbMigrationsOptions
                    {
                        AutomaticMigrationsEnabled = true,
                        AutomaticMigrationDataLossAllowed = true
                    });

                    dbContext.MigrateToLatestVersion();
                } catch(MigrateDatabaseException ex)
                {
                    Console.WriteLine("ERROR -> Could not migrate database -> " + ex.Message,ex);
                }
            }

			var dbContextAuth = serviceScope.ServiceProvider.GetService<AuthDbContext>();
			if (builder.ApiGeneratorConfig.DatabaseOptions.DatabaseType != DbType.InMemory)
				{
				try
					{
					dbContextAuth.MigrateToLatestVersion(new DbMigrationsOptions
						{
						AutomaticMigrationsEnabled = true,
						AutomaticMigrationDataLossAllowed = allowDataLoss
						});

					dbContextAuth.MigrateToLatestVersion();
					}
				catch (MigrateDatabaseException ex)
					{
					Console.WriteLine("ERROR -> Could not migrate database -> " + ex.Message, ex);
					}
				}


			return app;
        }



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