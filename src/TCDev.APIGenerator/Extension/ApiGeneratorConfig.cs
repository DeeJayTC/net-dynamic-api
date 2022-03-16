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


         //Load Cache Options
         CacheOptions = new CacheOptions();
         Configuration.Bind("Api:Cache", CacheOptions);
      }

      private readonly IConfigurationRoot Configuration;
      public CacheOptions CacheOptions { get; set; }


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
}