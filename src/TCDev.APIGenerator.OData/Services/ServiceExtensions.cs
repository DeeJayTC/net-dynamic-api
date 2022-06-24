using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TCDev.APIGenerator.Attributes;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Json;
using TCDev.APIGenerator.Odata;
using TCDev.APIGenerator.Schema;
using TCDev.Controllers;

namespace TCDev.APIGenerator.Services
{
    public static class ServiceExtensions
    {
        public static ApiGeneratorServiceBuilder AddAssemblyWithOData(this ApiGeneratorServiceBuilder builder, Assembly assembly)
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
                                new GenericTypeControllerFeatureProvider(builder.AssemblyService.Types, typeof(GenericODataController<,>)
                                )
                            )
            );


            return builder;
        }


        public static ApiGeneratorServiceBuilder AddAssemblyWithODataFromFile(this ApiGeneratorServiceBuilder builder, string apiDefinitionFile)
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
                                    new GenericTypeControllerFeatureProvider(builder.AssemblyService.Types, typeof(GenericODataController<,>)
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


        public static ApiGeneratorServiceBuilder AddAssemblyWithODataFromUri(this ApiGeneratorServiceBuilder builder, string apiDefinitionSource, string token)
        {

            if (builder.AssemblyService == null)
            {
                builder.AssemblyService = new AssemblyService();
                builder.Services.AddSingleton(builder.AssemblyService);
            }

            try
            {
            
                using(var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authentication", $"Bearer {token}");
                    var jsonDef = client.GetStringAsync(apiDefinitionSource).Result; //Synchronous on purpose!

                    var jsonDefsLocal = JsonConvert.DeserializeObject<List<JsonClassDefinition>>(jsonDef);
                    builder.AssemblyService.Types.AddRange(JsonClassService.CreateTypes(jsonDefsLocal));

                    builder.Services.AddMvc(options =>
                          options.Conventions.Add(new GenericControllerRouteConvention()))
                                  .ConfigureApplicationPartManager(manager =>
                                      manager.FeatureProviders.Add(
                                          new GenericTypeControllerFeatureProvider(builder.AssemblyService.Types, typeof(GenericODataController<,>)
                                          )
                                      )
                      );
                }


            }
            catch (FileNotFoundException ex)
            {
                throw new Exception($"Json Definition File could not be loaded from {apiDefinitionSource}", ex);
            }

            return builder;
        }

        public static ApiGeneratorServiceBuilder AddAssemblyWithODataRasepi(this ApiGeneratorServiceBuilder builder, Uri uri, string apiKey)
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
                                    new GenericTypeControllerFeatureProvider(builder.AssemblyService.Types, typeof(GenericODataController<,>)
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

    }
}
