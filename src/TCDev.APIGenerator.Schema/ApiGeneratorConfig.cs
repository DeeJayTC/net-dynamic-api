// TCDev.de 2022/03/16
// TCDev.APIGenerator.ApiGeneratorConfig.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TCDev.APIGenerator;

public class ApiGeneratorConfig
{
   public CacheOptions CacheOptions = new();
   public ApiOptions ApiOptions = new();
   public SwaggerOptions SwaggerOptions = new();
   public DatabaseOptions DatabaseOptions = new();
   public ODataOptions ODataOptions = new();
   public IdentityOptions IdentityOptions = new();
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
   public bool UseXmlComments = false;
   public string XmlCommentsFile = string.Empty;

   public string JsonMode = "local";
   public string JsonUri = "./ ApiDefinition.json";
}

public class CacheOptions
{
   public bool Enabled = true;
   public string Connection = "redis";
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
   public DbType DatabaseType = DbType.InMemory;
   public string? Connection = string.Empty;
   public bool EnableAutomaticMigration = true;

    public string MigrationAssembly { get; set; }
}

public class ODataOptions
{
   public bool EnableSelect = true;
   public bool EnableFilter = true;
   public bool EnableExpand = true;
   public bool EnableOrderBy = true;
   public bool EnableCompute  = true;
   public bool EnableNoDollarQueryOptions = false;
   public int MaxTop = 10000;
   public string OdataRoute = "/odata";
}

public class SwaggerOptions
{
   /// <summary>
   ///    Enable Swagger in Production
   /// </summary>
   public bool EnableProduction = true;

   public string Description = "Sample for TCDev API Generator";
   public string Version = "v1";
   public string Title = "TCDev Api Generator Demo";
   public string ContactMail = "test@test.de";
   public string ContactUri = "https://www.test.de";
   public string Route = "/swagger/v1/swagger.json";
}

public class IdentityOptions
{
    public bool EnableIdentity = false;
    public string Audience = "TCDevApiGenerator";
    public string Authority = "https://localhost:44300";
    public string[] Scopes = { "ReadWrite.All" };

    public bool ValidateIssuer = true;
    public string MetaDataUri = "";
    
    public bool ValidateAudience = true;
    public bool ValidateLifetime = true;
    public bool ValidateIssuerSigningKey = true;
}