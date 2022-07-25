// TCDev.de 2022/03/16
// TCDev.APIGenerator.ApiGeneratorExtension.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using EntityFramework.Triggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Extension.Swagger;
using TCDev.APIGenerator.Schema;
using TCDev.APIGenerator.Services;
using TCDev.Controllers;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Attributes;
using TCDev.APIGenerator.Json;
using TCDev.APIGenerator.Hooks;

namespace TCDev.APIGenerator.Extension
{

    public class ApiGeneratorServiceBuilder
    {
        public ApiGeneratorConfig ApiGeneratorConfig { get; set; }
        public IServiceCollection Services { get; set; }
        public AssemblyService AssemblyService { get; set; }

    }


    public static class ApiGeneratorExtension
    {


        public static ApiGeneratorServiceBuilder AddApiGeneratorServices(this IServiceCollection services)
        {
            var builder = new ApiGeneratorServiceBuilder();
            builder.ApiGeneratorConfig = new ApiGeneratorConfig();
            services.AddSingleton<ApiGeneratorServiceBuilder>(builder);

            builder.Services = services;

            builder.Services
                .AddHttpContextAccessor()
                .AddSingleton(typeof(ITriggers<,>), typeof(Triggers<,>))
                .AddSingleton(typeof(ITriggers<>), typeof(Triggers<>))
                .AddSingleton(typeof(ITriggers), typeof(Triggers))
                .AddSingleton<ApiGeneratorConfig>(builder.ApiGeneratorConfig)
                .AddScoped(typeof(IApplicationDataService<,>),typeof(ApplicationDataService<,>))
                .AddScoped(typeof(ApplicationDataService<,>))
                .AddScoped(typeof(IGenericRespository<,>), typeof(GenericRespository<,>));


            return builder;
        }

        public static ApiGeneratorServiceBuilder AddConfig(this ApiGeneratorServiceBuilder builder, string configSource)
        {
            builder.ApiGeneratorConfig = new ApiGeneratorConfig(configSource);
            return builder;
        }

        public static ApiGeneratorServiceBuilder AddConfig(this ApiGeneratorServiceBuilder builder, ApiGeneratorConfig config)
        {
            builder.ApiGeneratorConfig = config;
            return builder;
        }

        public static ApiGeneratorServiceBuilder AddConfig(this ApiGeneratorServiceBuilder builder, IConfiguration config)
        {
            builder.ApiGeneratorConfig = new ApiGeneratorConfig(config);
            return builder;
        }


        public static ApiGeneratorServiceBuilder AddAssembly(this ApiGeneratorServiceBuilder builder, Assembly assembly)
        {

            if (builder.AssemblyService == null)
            {
                builder.AssemblyService = new AssemblyService();
                builder.Services.AddSingleton(builder.AssemblyService);
            }

            builder.AssemblyService.Assemblies.Add(assembly);

            builder.AssemblyService.Types
                    .AddRange(assembly.GetExportedTypes()
                    .Where(x => x.GetCustomAttributes<ApiAttribute>()
                    .Any()));

            builder.Services.AddMvc(options =>
                options.Conventions.Add(new GenericControllerRouteConvention()))
                        .ConfigureApplicationPartManager(manager =>
                            manager.FeatureProviders.Add(
                                new GenericTypeControllerFeatureProvider(builder.AssemblyService.Types, typeof(GenericController<,>)
                                )
                            )
            );


            return builder;
        }


        public static ApiGeneratorServiceBuilder AddAssemblyRasepi(this ApiGeneratorServiceBuilder builder, Uri uri, string apiKey)
        {

            if (builder.AssemblyService == null)
            {
                builder.AssemblyService = new AssemblyService();
                builder.Services.AddSingleton(builder.AssemblyService);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("rasepi-api-key", apiKey);
                    //This is a blocking call, yes, on purpose!
                    var jsonDefRaw = client.GetStringAsync(uri).Result;
                    var jsonDefRemote = JsonConvert.DeserializeObject<List<JsonClassDefinition>>(jsonDefRaw);
                    builder.AssemblyService.Types.AddRange(JsonClassService.CreateTypes(jsonDefRemote));
                }

                builder.Services.AddMvc(options =>
                    options.Conventions.Add(new GenericControllerRouteConvention()))
                            .ConfigureApplicationPartManager(manager =>
                                manager.FeatureProviders.Add(
                                    new GenericTypeControllerFeatureProvider(builder.AssemblyService.Types, typeof(GenericController<,>)
                                    )
                                )
                );


            }
            catch (Exception ex)
            {
                throw new Exception($"Json Definition not found, make sure its stored in {uri}", ex);
            }

            return builder;
        }


        public static ApiGeneratorServiceBuilder AddAssembly(this ApiGeneratorServiceBuilder builder, string apiDefinitionFile)
        {

            if (builder.AssemblyService == null)
            {
                builder.AssemblyService = new AssemblyService();
                builder.Services.AddSingleton(builder.AssemblyService);
            }

            try
            {
                if (File.Exists(apiDefinitionFile))
                {
                    var jsonDefsLocal = JsonConvert.DeserializeObject<List<JsonClassDefinition>>(File.ReadAllText(apiDefinitionFile));
                    builder.AssemblyService.Types.AddRange(JsonClassService.CreateTypes(jsonDefsLocal));
                }

                builder.Services.AddMvc(options =>
                    options.Conventions.Add(new GenericControllerRouteConvention()))
                            .ConfigureApplicationPartManager(manager =>
                                manager.FeatureProviders.Add(
                                    new GenericTypeControllerFeatureProvider(builder.AssemblyService.Types, typeof(GenericController<,>)
                                    )
                                )
                );

            }
            catch (FileNotFoundException ex)
            {
                throw new Exception($"Json Definition File not found, make sure its stored in {apiDefinitionFile}", ex);
            }

            return builder;
        }


        public static ApiGeneratorServiceBuilder AddSwagger(this ApiGeneratorServiceBuilder builder, bool ShowODataQueryOptions = false)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(builder.ApiGeneratorConfig.SwaggerOptions.Version,
                    new OpenApiInfo
                    {
                        Title = builder.ApiGeneratorConfig.SwaggerOptions.Title,
                        Version = builder.ApiGeneratorConfig.SwaggerOptions.Version,
                        Description = builder.ApiGeneratorConfig.SwaggerOptions.Description,
                        Contact = new OpenApiContact
                        {
                            Email = builder.ApiGeneratorConfig.SwaggerOptions.ContactMail,
                            Url = new Uri(builder.ApiGeneratorConfig.SwaggerOptions.ContactUri)
                        }
                    });
                c.DocumentFilter<ShowInSwaggerFilter>();
                c.SchemaFilter<SwaggerSchemaFilter>();
                c.OperationFilter<IgnoreODataQueryOptionOperationFilter>();
                if(ShowODataQueryOptions) c.OperationFilter<EnableQueryFiler>();

                if (builder.ApiGeneratorConfig.ApiOptions.UseXmlComments)
                {
                    if (!string.IsNullOrEmpty(builder.ApiGeneratorConfig.ApiOptions.XmlCommentsFile))
                    {
                        throw new Exception("You need to set XMLCommentsFile option when using XMl Comments");
                    }

                    c.IncludeXmlComments(builder.ApiGeneratorConfig.ApiOptions.XmlCommentsFile, true);
                }

            });




            return builder;
        }


        public static IApplicationBuilder UseApiGenerator(this IApplicationBuilder app)
        {
            var builder = app.ApplicationServices.GetRequiredService<ApiGeneratorServiceBuilder>();

            if (builder.ApiGeneratorConfig.SwaggerOptions.Enabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    //c.InjectStylesheet("/SwaggerDarkTheme.css");
                    c.OAuthConfigObject = new OAuthConfigObject()
                    {
                        AppName = "APIGenerator",
                        ClientId = string.Empty,
                        ClientSecret = string.Empty,

                    };
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        $"{builder.ApiGeneratorConfig.SwaggerOptions.Title} {builder.ApiGeneratorConfig.SwaggerOptions.Version}"
                    );
                });
            }

            return app;
        }

        public static IEndpointRouteBuilder UseApiGeneratorEndpoints(this IEndpointRouteBuilder builder)
        {
            return builder;
        }
    }
}
