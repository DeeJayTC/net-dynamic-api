// TCDev.de 2022/03/16
// TCDev.APIGenerator.GenericDbContext.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TCDev.APIGenerator.Services;

namespace TCDev.ApiGenerator.Data
{
    public class GenericDbContext : DbContext
    {
        //public static IModel StaticModel { get; } = BuildStaticModel();
        private readonly AssemblyService assemblyService;

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
                    optionsBuilder.UseInMemoryDatabase("ApiGeneratorDB");
                    break;
                case DbType.Sql:
                    var connectionStringSql = configuration.GetConnectionString("ApiGeneratorDatabase");
                    optionsBuilder.UseSqlServer(connectionStringSql);
                    break;
                case DbType.SqLite:
                    var connectionStringSqLite = configuration.GetConnectionString("ApiGeneratorDatabase");
                    optionsBuilder.UseSqlite(connectionStringSqLite);
                    break;
                default:
                    throw new Exception("Database Type Unknown");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Add all types T using IEntityTypeConfiguration
            foreach (var asm in this.assemblyService.Assemblies)
            {
                builder.ApplyConfigurationsFromAssembly(asm);
            }

            // Add all other custom types, not implementing IEntityTypeConfiguration
            foreach (var customType in this.assemblyService.Types.Where(x => x.IsAssignableFrom(typeof(IEntityTypeConfiguration<>))))
            {
                builder.Entity(customType);
            }

            base.OnModelCreating(builder);
        }


        /// <summary>
        ///     Generate EDM Model for OData functionality
        /// </summary>
        /// <returns></returns>
        public static IEdmModel GetEdmModel(AssemblyService service)
        {
            var builder = new ODataConventionModelBuilder();
            foreach (var customType in service.Types)
            {
                builder.AddEntityType(customType);
            }

            return builder.GetEdmModel();
        }


        public GenericDbContext(
            DbContextOptions<GenericDbContext> options,
            IConfiguration config,
            AssemblyService assemblyService) : base(options)
        {
            this.assemblyService = assemblyService;
        }

        #region If you're targeting EF Core

        public override int SaveChanges()
        {
            return this.SaveChangesWithTriggers(base.SaveChanges);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, true, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion
    }
}
