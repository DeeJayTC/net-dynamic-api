using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.Data.Postgres;

public class ProviderConfig : IDatabaseProviderConfiguration
{
    private IConfiguration configuration;
    private ApiGeneratorServiceBuilder builder;
    public ProviderConfig(IConfiguration config, ApiGeneratorServiceBuilder builder)
    {
        this.configuration = config;
        this.builder = builder;
    }

    public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (string.IsNullOrEmpty(builder.ApiGeneratorConfig.DatabaseOptions.Connection)
            &&
            string.IsNullOrEmpty(builder.ApiGeneratorConfig.DatabaseOptions.ConnectionStringName)
           ) throw new ArgumentException("Please set either Connection or ConnectonStringName, (and not both!)");

        var connection = !string.IsNullOrEmpty(builder.ApiGeneratorConfig.DatabaseOptions.ConnectionStringName) ?
            configuration.GetConnectionString(builder.ApiGeneratorConfig.DatabaseOptions.ConnectionStringName) :
            builder.ApiGeneratorConfig.DatabaseOptions.Connection;


        optionsBuilder.UseNpgsql(connection);
    }
}
