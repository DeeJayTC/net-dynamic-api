// TCDev.de 2022/03/16
// TCDev.APIGenerator.ApiGeneratorExtension.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using EFCore.AutomaticMigrations;
using EntityFramework.Triggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Data;
using TCDev.APIGenerator.Extension;
using TCDev.ApiGenerator.Json;
using TCDev.APIGenerator.Schema;
using TCDev.APIGenerator.Services;
using TCDev.Controllers;

namespace TCDev.ApiGenerator.Extension
{
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
                .AddSingleton(typeof(ITriggers), typeof(Triggers))
                .AddScoped(typeof(ODataScopeLookup<,>))
                .AddScoped(typeof(IGenericRespository<,>), typeof(GenericRespository<,>));




            
            //Add Framework Services & Options, we use the current assembly to get classes. 
            var assemblyService = new AssemblyService();
            services.AddSingleton(assemblyService);

            var jsonDefs = JsonConvert.DeserializeObject<List<JsonClassDefinition>>(File.ReadAllText("./ApiDefinition.json"));
            assemblyService.Types.AddRange(JsonClassBuilder.CreateTypes(jsonDefs));
            assemblyService.Types.AddRange(assembly.GetExportedTypes()
                .Where(x => x.GetCustomAttributes<ApiAttribute>()
                    .Any()));


            // Put everything together
            services.AddMvc(options =>
                    options.Conventions.Add(new GenericControllerRouteConvention()))
                .ConfigureApplicationPartManager(manager =>
                    // Add our controller feature provider
                    manager.FeatureProviders.Add(new GenericTypeControllerFeatureProvider(assemblyService.Types))
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
                    {
                        throw new Exception("You need to set XMLCommentsFile option when using XMl Comments");
                    }

                    c.IncludeXmlComments(ApiGeneratorConfig.ApiOptions.XmlCommentsFile, true);
                }
            });


            if (ApiGeneratorConfig.ODataOptions.Enabled)
            {
                services
                    .AddControllers()
                    .AddOData(opt =>
                    {
                        opt.AddRouteComponents("odata", GenericDbContext.GetEdmModel(assemblyService));
                        opt.EnableNoDollarQueryOptions = true;
                        opt.EnableQueryFeatures(20000);
                        opt.Select()
                            .Expand()
                            .OrderBy()
                            .SetMaxTop(10000)
                            .Count()
                            .SkipToken()
                            .Filter();
                    })
                    .AddJsonOptions(o => { o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }
                    );
            }
            else
            {
                services
                    .AddControllers()
                    .AddJsonOptions(o => { o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
            }

            return services;
        }


        public static IApplicationBuilder UseAutomaticApiMigrations(this IApplicationBuilder app, bool allowDataLoss = false)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<GenericDbContext>();
            if (ApiGeneratorConfig.DatabaseOptions.DatabaseType != DbType.InMemory)
            {
                dbContext.MigrateToLatestVersion(new DbMigrationsOptions
                {
                    AutomaticMigrationsEnabled = true, 
                    AutomaticMigrationDataLossAllowed = allowDataLoss
                });
            }

            return app;
        }

        public static IApplicationBuilder UseApiGenerator(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/SwaggerDarkTheme.css");
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    $"{ApiGeneratorConfig.SwaggerOptions.Title} {ApiGeneratorConfig.SwaggerOptions.Version}"
                );
            });

            return app;
        }

        public static IEndpointRouteBuilder UseApiGeneratorEndpoints(this IEndpointRouteBuilder builder)
        {
            return builder;
        }
    }
}
