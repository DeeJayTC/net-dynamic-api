using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.SQL;

public static partial class ServiceExtension
{
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
            optionsBuilder.UseNpgsql(builder.ApiGeneratorConfig.DatabaseOptions.Connection);
        }
    }

}
