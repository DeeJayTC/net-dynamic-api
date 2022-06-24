// TCDev.de 2022/03/16
// TCDev.APIGenerator.ApiGeneratorConfig.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using System.Reflection;
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


    public void BindConfig()
    {
        //Load Options
        this.configuration.Bind("Api:Basic", this.ApiOptions);
        this.configuration.Bind("Api:Cache", this.CacheOptions);
        this.configuration.Bind("Api:Swagger", this.SwaggerOptions);
        this.configuration.Bind("Api:Database", this.DatabaseOptions);
        this.configuration.Bind("Api:Odata", this.ODataOptions);
        this.configuration.Bind("Api:Identity", this.IdentityOptions);
    }

    public ApiGeneratorConfig() {

        this.configuration =  new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile("apiGeneratorConfig.json", true)
                        .AddJsonFile("secrets.json", true)
                        .AddEnvironmentVariables()
                        .Build();
        BindConfig();
    }

    public ApiGeneratorConfig(string configFile) {
        this.configuration =  new ConfigurationBuilder()
                            .AddJsonFile(configFile)
                            .Build();

        BindConfig();

    }



    public ApiGeneratorConfig(IConfiguration config)
   {
        this.configuration = config
                           ?? new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json")
                              .AddJsonFile("apiGeneratorConfig.json", true)
                              .AddJsonFile("secrets.json", true)
                              .AddEnvironmentVariables()
                              .Build();
       
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


    public bool UseHealthCheck = true;
    public bool UseHealthCheckUI = true;
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
   public DbType DatabaseType { get; set; } = DbType.InMemory;
   public string? Connection { get; set; } = string.Empty;
   public bool EnableAutomaticMigration { get; set; } = true;

    public string MigrationAssembly { get; set; } = Assembly.GetExecutingAssembly().FullName;
}

public class ODataOptions
{
   public bool EnableSelect { get; set; } = true;
   public bool EnableFilter { get; set; } = true;
   public bool EnableExpand { get; set; } = true;
   public bool EnableOrderBy { get; set; } = true;
   public bool EnableCompute { get; set; } = true;
   public bool EnableNoDollarQueryOptions { get; set; } = false;
   public int MaxTop { get; set; } = 10000;
   public string OdataRoute { get; set; } = "/odata";
}

public class SwaggerOptions
{
   /// <summary>
   ///    Enable Swagger in Production
   /// </summary>
   public bool Enabled { get; set; } = true;

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