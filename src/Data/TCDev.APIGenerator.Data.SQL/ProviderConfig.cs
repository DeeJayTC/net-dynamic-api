using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.Extension
{
    public static partial class ServiceExtension
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
    }
}