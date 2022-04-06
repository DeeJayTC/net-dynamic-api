// TCDev.de 2022/03/16
// TCDev.APIGenerator.GenericDbContext.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using TCDev.ApiGenerator.Attributes;
using TCDev.APIGenerator.Services;

namespace TCDev.ApiGenerator.Data;

public class GenericDbContext : DbContext
{
   protected IHttpContextAccessor HttpContextAccessor { get; }

   //public static IModel StaticModel { get; } = BuildStaticModel();
   public static IEdmModel EdmModel { get; } = GetEdmModel();
   private readonly AssemblyService assemblyService;

   //public GenericDbContext()
   //{
   //}

   public GenericDbContext(
      DbContextOptions<GenericDbContext> options,
      IConfiguration config,
      AssemblyService assemblyService) : base(options)
   {
      this.assemblyService = assemblyService;
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      if (!optionsBuilder.IsConfigured)
      {
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
               throw new Exception("Database Type Unkown");
         }
      }
   }

   // -> Tenant Isolation
   //public void SetGlobalQuery<T>(ModelBuilder builder) where T : EntityBase<T>
   //{
   //    var user = HttpContextAccessor.HttpContext.GetUser();
   //    builder.Entity<T>().HasKey(e => e.Id);
   //    builder.Entity<T>().HasQueryFilter(e => e.TenantId == user.TenantId);
   //}

   protected override void OnModelCreating(ModelBuilder builder)
   {
      // Add all types T using IEntityTypeConfiguration
      builder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());


      foreach (var customType in assemblyService.Types.Where(x => x.GetInterface("IEntityTypeConfiguration`1") == null))
         builder.Entity(customType);

      base.OnModelCreating(builder);
   }


   /// <summary>
   ///    Generate EDM Model for OData functionalities
   /// </summary>
   /// <returns></returns>
   public static IEdmModel GetEdmModel()
   {
      var customTypes = Assembly.GetEntryAssembly()
         .GetExportedTypes()
         .Where(x => x.GetCustomAttributes<ApiAttribute>()
            .Any());
      var builder = new ODataConventionModelBuilder();
      foreach (var customType in customTypes)
      {
         var newType = builder.AddEntityType(customType);
      }

      return builder.GetEdmModel();
   }


   //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
   //{
   //          //var entries = ChangeTracker
   //          //    .Entries()
   //          //    .Where(e =>
   //          //            e.Entity is IObjectBase<string>
   //          //         && (e.State == EntityState.Added
   //          //         || e.State == EntityState.Modified
   //          //         || e.State == EntityState.Deleted
   //          //         )
   //          //    );

   //          //UpdateEntries<int>(user, entries);
   //          //UpdateEntries<string>(user, entries);
   //          //UpdateEntries<Guid>(user, entries);

   //          return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
   //}


   //private static IModel BuildStaticModel()
   //{
   //   using var dbContext = new GenericDbContext();
   //   return dbContext.Model;
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
