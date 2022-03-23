// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.IO;
using Microsoft.Extensions.Configuration;

namespace TCDev.ApiGenerator.Extension
{
   public class ApiGeneratorConfig
   {
      public ApiGeneratorConfig()
      {
         Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();


         //Load Options
         Configuration.Bind("Api:Cache", CacheOptions);
         Configuration.Bind("Api:Swagger", SwaggerOptions);
      }

      private readonly IConfigurationRoot Configuration;
      public CacheOptions CacheOptions { get; set; } = new CacheOptions();
      public SwaggerOptions SwaggerOptions { get; set; } = new SwaggerOptions();

      public string MetadataRoute { get; set; } = "odata";
   }

   public class CacheOptions
   {
      public bool Enabled { get; set; } = true;
      public string Connection { get; set; } = "redis";
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
