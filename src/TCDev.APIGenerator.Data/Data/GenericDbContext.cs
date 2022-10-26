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
using TCDev.APIGenerator.Interfaces;
using TCDev.APIGenerator.Services;
using Directory = System.IO.Directory;
using Innofactor.EfCoreJsonValueConverter;
using TCDev.APIGenerator.Model.Interfaces;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Model;

namespace TCDev.APIGenerator.Data
{


    public class GenericDbContext : DbContext
    {
        private readonly AssemblyService assemblyService;
        private readonly IHttpContextAccessor context;
        private readonly IDatabaseProviderConfiguration dbConfigProvider;
        private readonly IConfiguration config;

        public GenericDbContext(
            DbContextOptions<GenericDbContext> options,
            IConfiguration config,
            AssemblyService assemblyService,
            IHttpContextAccessor accessor,
            IDatabaseProviderConfiguration databaseProviderConfiguration) : base(options)
        {
            this.assemblyService = assemblyService;
            this.context = accessor;
            this.dbConfigProvider = databaseProviderConfiguration;
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            dbConfigProvider.OnConfiguring(optionsBuilder);

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
                var tenant = this.context.HttpContext.GetUser().TenantId;
                builder.Entity(customType).HasQueryFilter((IHasTenantId p) => p.TenantId == tenant);
            }

            builder.AddJsonFields();


            base.OnModelCreating(builder);
        }



        // Applying BaseEntity rules to all entities that inherit from it.
        // Define MethodInfo member that is used when model is built.
        //
        //static readonly MethodInfo SetGlobalQueryMethod = 
        //    typeof(GenericDbContext).GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //    .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        // This method is called for every loaded entity type in OnModelCreating method.
        // Here type is known through generic parameter and we can use EF Core methods.
        //public void SetGlobalQuery<T>(ModelBuilder builder) where T : class
        //{
            
        //    builder.Entity<T>().HasKey(e => e.Id);
        //    builder.Entity<T>().HasQueryFilter(e => e.TenantId == _tenantProvider.GetTenantId());
        //}


        #region If you're targeting EF Core

        //public override int SaveChanges()
        //{
        //    return this.SaveChangesWithTriggers(base.SaveChanges);
        //}

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess);
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, true, cancellationToken);
        //}

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        //    CancellationToken cancellationToken = default)
        //{
        //    return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken);
        //}

        #endregion
    }
}
