// TCDev.de 2022/04/24
// TCDev.APIGenerator.AuthDbContext.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TCDev.ApiGenerator;
using TCDev.APIGenerator.Model;

namespace TCDev.APIGenerator.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("secrets.json", true)
                .Build();
            var config = new ApiGeneratorConfig(configuration);
            // Add Database Context

            switch (config.DatabaseOptions.DatabaseType)
            {
                case DbType.InMemory:
                    optionsBuilder.UseInMemoryDatabase("ApiGeneratorAuth");
                    break;
                case DbType.Sql:
                    var connectionStringSql = configuration.GetConnectionString("ApiGeneratorAuth");
                    optionsBuilder.UseSqlServer(connectionStringSql);
                    break;
                case DbType.SqLite:
                    var connectionStringSqLite = configuration.GetConnectionString("ApiGeneratorAuth");
                    optionsBuilder.UseSqlite(connectionStringSqLite);
                    break;
                default:
                    throw new Exception("Database Type Unknown");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
