// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TCDev.ApiGenerator.Extension
{
   public class ApiGeneratorConfig
   {
      IConfiguration configuration;
      public ApiGeneratorConfig(IConfiguration config)
      {
         configuration = config;
         if(configuration == null) {
            configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .AddJsonFile("secrets.json", true)
               .AddEnvironmentVariables()
               .Build();
         }

         //Load Options
         configuration.Bind("Api:Cache", CacheOptions);
         configuration.Bind("Api:Swagger", SwaggerOptions);
         configuration.Bind("Api:Database", DatabaseOptions);
      }

      private readonly IConfigurationRoot Configuration;
      public CacheOptions CacheOptions { get; set; } = new CacheOptions();
      public SwaggerOptions SwaggerOptions { get; set; } = new SwaggerOptions();
      public DatabaseOptions DatabaseOptions { get; set; } = new DatabaseOptions();

      public string MetadataRoute { get; set; } = "odata";
   }

   public class CacheOptions
   {
      public bool Enabled { get; set; } = true;
      public string Connection { get; set; } = "redis";
   }


   public enum DBType
   {
      InMemory,
      SQL,
      //Postgres,
      SQLite
   }

   public class DatabaseOptions
   {
      public DBType DatabaseType { get; set; } = DBType.InMemory;
      public string? Connection { get; set; } = String.Empty;
      public bool EnableAutomaticMigration { get; set; } = true;
   }

   public class ODataFunctions
   {
      public bool EnableSelect { get; set; } = true;
      public bool EnableFilter { get; set; } = true;
      public bool EnableSort { get; set; } = true;
   }

   public class SwaggerOptions
   {
      /// <summary>
      /// Enable Swagger in Production
      /// </summary>
      public bool EnableProduction { get; set; } = true;
      public string Description { get; set; } = "Sample for TCDev API Generator";
      public string Version { get; set; } = "v1";
      public string Title { get; set; } = "TCDev Api Generator Demo";
      public string ContactMail { get; set; } = "test@test.de";
      public string ContactUri { get; set; } = "https://www.test.de";
      public string Route { get; set; } = "/swagger/v1/swagger.json";
   }
}
