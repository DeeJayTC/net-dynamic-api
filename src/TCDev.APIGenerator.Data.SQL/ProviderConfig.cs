using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.Extension
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
            optionsBuilder.UseSqlServer(builder.ApiGeneratorConfig.DatabaseOptions.Connection);
        }
    }
}