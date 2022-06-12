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
        public static ApiGeneratorServiceBuilder AddAssemblyWithOdata(this ApiGeneratorServiceBuilder builder, Assembly assembly)
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


        public static ApiGeneratorServiceBuilder AddAssemblyWithOData(this ApiGeneratorServiceBuilder builder, string apiDefinitionFile)
        {

            if (builder.AssemblyService != null)
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

    }
}
