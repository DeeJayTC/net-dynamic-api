// TCDev.de 2022/03/16
// TCDev.APIGenerator.ApiGeneratorExtension.cs
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using EFCore.AutomaticMigrations;
using EntityFramework.Triggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Data;
using TCDev.APIGenerator.Extension;
using TCDev.ApiGenerator.Json;
using TCDev.APIGenerator.Schema;
using TCDev.Controllers;

namespace TCDev.ApiGenerator.Extension;

public static class ApiGeneratorExtension
{
   public static ApiGeneratorConfig ApiGeneratorConfig { get; set; } = new(null);

   public static IServiceCollection AddApiGeneratorServices(
      this IServiceCollection services,
      IConfiguration config,
      Assembly assembly)
   {
      ApiGeneratorConfig = new ApiGeneratorConfig(config);

      // Add Database Context

      switch (ApiGeneratorConfig.DatabaseOptions.DatabaseType)
      {
         case DbType.InMemory:
            services.AddDbContext<GenericDbContext>(options =>
               options.UseInMemoryDatabase("ApiGeneratorDB"));
            break;
         case DbType.Sql:
            services.AddDbContext<GenericDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("ApiGeneratorDatabase"),
                  b => b.MigrationsAssembly(assembly.FullName)));
            break;
         case DbType.SqLite:
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


      var JsonDef = new JsonClassDefinition()
      {
         Name = "TestGenerated",
         RouteTemplate = "/testGenerated",
         Fields = new List<Field>(){
            new Field
            {
               Name = "Id",
               Type = "int"
            },
            new Field
            {
               Name = "Name",
               Type = "string"
            },

         }
      };

      // Get all types defined in JSON
      var genericAssembly = JsonClassBuilder.CreateClass(JsonDef);

      // Get all types in entry assembly
      var types = assembly.GetExportedTypes().Where(x => x.GetCustomAttributes<ApiAttribute>().Any());

      // generate type list
      var typesToLoad = new List<Type>
      {
         genericAssembly
      };
      typesToLoad.AddRange(types);


      // Put everything together
      services.AddMvc(options =>
            options.Conventions.Add(new GenericControllerRouteConvention()))
            .ConfigureApplicationPartManager(manager =>
               // Add our controller feature provider
               manager.FeatureProviders.Add(new GenericTypeControllerFeatureProvider(typesToLoad))
         );


      services.AddSwaggerGen(c =>
      {
         c.SwaggerDoc(ApiGeneratorConfig.SwaggerOptions.Version,
            new OpenApiInfo
            {
               Title = ApiGeneratorConfig.SwaggerOptions.Title,
               Version = ApiGeneratorConfig.SwaggerOptions.Version,
               Description = ApiGeneratorConfig.SwaggerOptions.Description,
               Contact = new OpenApiContact
               {
                  Email = ApiGeneratorConfig.SwaggerOptions.ContactMail, Url = new Uri(ApiGeneratorConfig.SwaggerOptions.ContactUri)
               }
            });

         c.DocumentFilter<ShowInSwaggerFilter>();
         c.SchemaFilter<SwaggerSchemaFilter>();

         if (ApiGeneratorConfig.ApiOptions.UseXmlComments)
         {
            if (!string.IsNullOrEmpty(ApiGeneratorConfig.ApiOptions.XmlCommentsFile))
               throw new Exception("You need to set XMLCommentsFile option when using XMl Comments");
            c.IncludeXmlComments(ApiGeneratorConfig.ApiOptions.XmlCommentsFile, true);
         }
      });


      if (ApiGeneratorConfig.ODataOptions.Enabled)
         services
            .AddControllers()
            .AddOData(opt =>
            {
               opt.AddRouteComponents("odata", GenericDbContext.EdmModel);
               opt.EnableNoDollarQueryOptions = true;
               opt.EnableQueryFeatures(20000);
               opt.Select()
                  .Expand()
                  .Filter();
            })
            .AddJsonOptions(o => { o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }
            );
      else
         services
            .AddControllers()
            .AddJsonOptions(o => { o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

      return services;
   }


   public static IApplicationBuilder UseAutomaticApiMigrations(this IApplicationBuilder app, bool allowDataLoss = false)
   {
      using var serviceScope = app.ApplicationServices.CreateScope();
      var dbContext = serviceScope.ServiceProvider.GetService<GenericDbContext>();
      if (ApiGeneratorConfig.DatabaseOptions.DatabaseType != DbType.InMemory)
         dbContext.MigrateToLatestVersion(new DbMigrationsOptions
         {
            AutomaticMigrationsEnabled = true, AutomaticMigrationDataLossAllowed = allowDataLoss
         });

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
