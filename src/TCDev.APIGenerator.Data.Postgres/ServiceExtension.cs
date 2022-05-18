using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System.Reflection;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Extension;

namespace TCDev.APIGenerator.SQL;

public static class ServiceExtension
{

    private static ApiGeneratorServiceBuilder AddDataContextSQL(
        this ApiGeneratorServiceBuilder builder, 
        Action<NpgsqlDbContextOptionsBuilder>? NpgsqlOptions = null)
    {

        if (builder.ApiGeneratorConfig.DatabaseOptions.Connection == null)
        {
            throw new ArgumentException("Provide a connection string in configuration before initiating Database");
        }

        
        builder.Services.AddDbContext<GenericDbContext>(options =>
        {
 
            if(NpgsqlOptions != null)
            {
                options.UseNpgsql(connectionString: builder.ApiGeneratorConfig.DatabaseOptions.Connection, NpgsqlOptions);
                
            }  else  
            {

                options.UseNpgsql(connectionString: builder.ApiGeneratorConfig.DatabaseOptions.Connection, b =>
                {
                    if (builder.ApiGeneratorConfig.DatabaseOptions.EnableAutomaticMigration)
                    {
                        b.MigrationsAssembly(builder.ApiGeneratorConfig.DatabaseOptions.MigrationAssembly);
                    }
                });
            }
    

        });
        return builder;

    }

}
