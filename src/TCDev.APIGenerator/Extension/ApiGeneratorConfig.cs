// TCDev.de 2022/03/16
// TCDev.APIGenerator.ApiGeneratorConfig.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TCDev.ApiGenerator;

public class ApiGeneratorConfig
{
   public CacheOptions CacheOptions { get; set; } = new();
   public ApiOptions ApiOptions { get; set; } = new();
   public SwaggerOptions SwaggerOptions { get; set; } = new();
   public DatabaseOptions DatabaseOptions { get; set; } = new();
   public ODataFunctions ODataOptions { get; set; } = new();
   public IdentityOptions IdentityOptions { get; set; } = new();
   private readonly IConfiguration configuration;

   public ApiGeneratorConfig(IConfiguration config)
   {
      this.configuration = config
                           ?? new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json")
                              .AddJsonFile("apiGeneratorConfig.json",true)
                              .AddJsonFile("secrets.json", true)
                              .AddEnvironmentVariables()
                              .Build();

      //Load Options
      this.configuration.Bind("Api:Basic", this.ApiOptions);
      this.configuration.Bind("Api:Cache", this.CacheOptions);
      this.configuration.Bind("Api:Swagger", this.SwaggerOptions);
      this.configuration.Bind("Api:Database", this.DatabaseOptions);
      this.configuration.Bind("Api:Odata", this.ODataOptions);
      this.configuration.Bind("Api:Identity", this.IdentityOptions);
    }
}

public class ApiOptions
{
   public bool UseXmlComments { get; set; } = false;
   public string XmlCommentsFile { get; set; } = string.Empty;

   public string JsonMode { get; set; } = "local";
   public string JsonUri { get; set; } = "./ ApiDefinition.json";
}

public class CacheOptions
{
   public bool Enabled { get; set; } = true;
   public string Connection { get; set; } = "redis";
}

public enum DbType
{
   InMemory,
   Sql,

   //Postgres,
   SqLite
}

public class DatabaseOptions
{
   public DbType DatabaseType { get; set; } = DbType.InMemory;
   public string? Connection { get; set; } = string.Empty;
   public bool EnableAutomaticMigration { get; set; } = true;
}

public class ODataFunctions
{
   public bool Enabled { get; set; } = false;
   public bool EnableSelect { get; set; } = true;
   public bool EnableFilter { get; set; } = true;
   public bool EnableSort { get; set; } = true;
}

public class SwaggerOptions
{
   /// <summary>
   ///    Enable Swagger in Production
   /// </summary>
   public bool EnableProduction { get; set; } = true;

   public string Description { get; set; } = "Sample for TCDev API Generator";
   public string Version { get; set; } = "v1";
   public string Title { get; set; } = "TCDev Api Generator Demo";
   public string ContactMail { get; set; } = "test@test.de";
   public string ContactUri { get; set; } = "https://www.test.de";
   public string Route { get; set; } = "/swagger/v1/swagger.json";
}

public class IdentityOptions
{
    public bool EnableIdentity { get; set; } = false;
    public string Audience { get; set; } = "TCDevApiGenerator";
    public string Authority { get; set; } = "https://localhost:44300";
    public string[] Scopes { get; set; } = { "ReadWrite.All" };

    public bool ValidateIssuer { get; set; } = true;
    public string MetaDataUri { get; set; } = "";
    
    public bool ValidateAudience { get; set; } = true;
    public bool ValidateLifetime { get; set; } = true;
    public bool ValidateIssuerSigningKey { get; set; } = true;
}