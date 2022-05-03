// TCDev.de 2022/03/16
// TCDev.APIGenerator.GenericDbContext.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TCDev.APIGenerator.Extension;
using TCDev.ApiGenerator.Interfaces;
using TCDev.APIGenerator.Services;
using Directory = System.IO.Directory;

namespace TCDev.ApiGenerator.Data
{
    public class GenericDbContext : DbContext
    {
        //public static IModel StaticModel { get; } = BuildStaticModel();
        private readonly AssemblyService assemblyService;
        private readonly IHttpContextAccessor context;

        public GenericDbContext(
            DbContextOptions<GenericDbContext> options,
            IConfiguration config,
            AssemblyService assemblyService,
            IHttpContextAccessor accessor) : base(options)
        {
            this.assemblyService = assemblyService;
            this.context = accessor;
        }

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
            foreach (var customType in this.assemblyService.Types.Where(x => !x.IsAssignableFrom(typeof(IEntityTypeConfiguration<>))))
            {
                builder.Entity(customType);
            }

            // handle Tenant Filters
            foreach (var customType in this.assemblyService.Types.Where(x => x.IsAssignableFrom(typeof(IHasTenantId))))
            {
                // Get current tenantID
                var tenant = this.context.HttpContext.GetUser().Tenant;
                //builder.Entity(customType).HasQueryFilter(p => p.TenantId == tenant.TenantId);
            }



            base.OnModelCreating(builder);
        }


        public static IEdmModel GetEdmModel(AssemblyService service)
        {
            var builder = new ODataConventionModelBuilder();
            var entitySetMethod = typeof(ODataConventionModelBuilder).GetMethod(nameof(ODataConventionModelBuilder.EntitySet));
            foreach (var customType in service.Types)
            {
                builder.AddEntityType(customType);
                var genericEntitySetMethod = entitySetMethod.MakeGenericMethod(customType);
                genericEntitySetMethod.Invoke(builder, new object[] { customType.Name });
            }

            return builder.GetEdmModel();
        }


        //// Applying BaseEntity rules to all entities that inherit from it.
        //// Define MethodInfo member that is used when model is built.
        ////
        //static readonly MethodInfo SetGlobalQueryMethod = typeof(GenericDbContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //    .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        //// This method is called for every loaded entity type in OnModelCreating method.
        //// Here type is known through generic parameter and we can use EF Core methods.
        //public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        //{
        //    builder.Entity<T>().HasKey(e => e.Id);
        //    builder.Entity<T>().HasQueryFilter(e => e.TenantId == _tenantProvider.GetTenantId());
        //}


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
