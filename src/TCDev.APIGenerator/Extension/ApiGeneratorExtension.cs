// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Reflection;
using EntityFramework.Triggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCDev.ApiGenerator.Data;
using TCDev.Controllers;
using Microsoft.AspNetCore.Routing;
using TCDev.APIGenerator.Extension;
using Microsoft.OpenApi.Models;
using EFCore.AutomaticMigrations;
using System;

namespace TCDev.ApiGenerator.Extension
{
   public static class ApiGeneratorExtension
   {

      public static ApiGeneratorConfig ApiGeneratorConfig { get; set; } = new ApiGeneratorConfig(null);

      public static IServiceCollection AddApiGeneratorServices(
         this IServiceCollection services,
         IConfiguration config,
         Assembly assembly)
      {

         ApiGeneratorConfig = new ApiGeneratorConfig(config);

         // Add Database Context

         switch(ApiGeneratorConfig.DatabaseOptions.DatabaseType)
         {
            case DBType.InMemory:
               services.AddDbContext<GenericDbContext>(options =>
                  options.UseInMemoryDatabase("ApiGeneratorDB"));
               break;
            case DBType.SQL:
               services.AddDbContext<GenericDbContext>(options =>
                  options.UseSqlServer(config.GetConnectionString("ApiGeneratorDatabase"),
                  b => b.MigrationsAssembly(assembly.FullName)));
               break;
            case DBType.SQLite:
               services.AddDbContext<GenericDbContext>(options =>
                  options.UseSqlite(config.GetConnectionString("ApiGeneratorDatabase"),
                  b => b.MigrationsAssembly(assembly.FullName)));
               break;
            default:
               throw new Exception("Database Type Unkown");
         }

         services
            .AddSingleton(typeof(ITriggers<,>), typeof(Triggers<,>))
            .AddSingleton(typeof(ITriggers<>), typeof(Triggers<>))
            .AddSingleton(typeof(ITriggers), typeof(Triggers));

         // Add Services
         services.AddScoped(typeof(IGenericRespository<,>), typeof(GenericRespository<,>));


         //Add Framework Services & Options, we use the current assembly to get classes. 
         // Todo: Add option to add any custom assembly
         services.AddMvc(o =>
               o.Conventions.Add(new GenericControllerRouteConvention()))
                  .ConfigureApplicationPartManager(m =>
                     m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider(new[] { assembly.FullName }))
            );


         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc(ApiGeneratorConfig.SwaggerOptions.Version,
               new OpenApiInfo
               {
                  Title = ApiGeneratorConfig.SwaggerOptions.Title,
                  Version = ApiGeneratorConfig.SwaggerOptions.Version,
                  Description = ApiGeneratorConfig.SwaggerOptions.Description,
                  Contact = new OpenApiContact() { 
                     Email = ApiGeneratorConfig.SwaggerOptions.ContactMail, 
                     Url = new System.Uri(ApiGeneratorConfig.SwaggerOptions.ContactUri)
                  }
               });

            c.DocumentFilter<ShowInSwaggerFilter>();
            if(ApiGeneratorConfig.APIOptions.UseXMLComments)
            {
               if (!string.IsNullOrEmpty(ApiGeneratorConfig.APIOptions.XMLCommentsFile))
               {
                  throw new Exception("You need to set XMLCommentsFile option when using XMl Comments");
               } else  {
                  c.IncludeXmlComments(ApiGeneratorConfig.APIOptions.XMLCommentsFile, true);
               }
            }

         });


         if(ApiGeneratorConfig.ODataOptions.EnableOData)
         {
            services.AddControllers().AddOData(opt =>
            {
               opt.AddRouteComponents("odata", GenericDbContext.EdmModel);
               opt.EnableNoDollarQueryOptions = true;
               opt.EnableQueryFeatures(20000);
               opt.Select().Expand().Filter();
            });
         } else {
            services.AddControllers();
         }

         return services;
      }


      public static IApplicationBuilder UseAutomaticAPIMigrations(this IApplicationBuilder app, bool AllowDataLoss = false)
      {
         using(var serviceScope = app.ApplicationServices.CreateScope())
         {
            var dbContext = serviceScope.ServiceProvider.GetService<GenericDbContext>();
            if(ApiGeneratorConfig.DatabaseOptions.DatabaseType != DBType.InMemory) { 
               dbContext.MigrateToLatestVersion(new DbMigrationsOptions
               {
                  AutomaticMigrationsEnabled = true,
                  AutomaticMigrationDataLossAllowed = AllowDataLoss
               });
            }
         }
         
         return app;
      }

      public static IApplicationBuilder UseApiGenerator(this IApplicationBuilder app)
      {

         app.UseSwagger();
         app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ApiGeneratorConfig.SwaggerOptions.Title} {ApiGeneratorConfig.SwaggerOptions.Version}"));
         return app;
      }

      public static IEndpointRouteBuilder UseApiGeneratorEndpoints(this IEndpointRouteBuilder builder)
      {
         return builder;
      }


   }
}