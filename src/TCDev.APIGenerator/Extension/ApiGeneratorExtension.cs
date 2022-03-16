// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Reflection;
using EntityFramework.Triggers;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCDev.ApiGenerator.Data;
using TCDev.Controllers;

namespace TCDev.ApiGenerator.Extension
{
   public static class ApiGeneratorExtension
   {
      public static IServiceCollection AddApiGeneratorServices(
         this IServiceCollection services,
         IConfiguration config,
         Assembly assembly)
      {
         // Add Database Context
         services.AddDbContext<GenericDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("ApiGeneratorDatabase"),
               b => b.MigrationsAssembly(assembly.FullName)));

         services
            .AddSingleton(typeof(ITriggers<,>), typeof(Triggers<,>))
            .AddSingleton(typeof(ITriggers<>), typeof(Triggers<>))
            .AddSingleton(typeof(ITriggers), typeof(Triggers));

         // Add Services
         services.AddScoped(typeof(IGenericRespository<,>), typeof(GenericRespository<,>));


         // Add Framework Services & Options, we use the current assembly to get classes. 
         // Todo: Add option to add any custom assembly
         services.AddMvc(o => o.Conventions.Add(new GenericControllerRouteConvention()))
            .ConfigureApplicationPartManager(m =>
               m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider(new[] {assembly.FullName}))
            );

         services.AddControllers().AddOData(opt =>
            {
               opt.AddRouteComponents("odata", GenericDbContext.EdmModel);
               opt.EnableNoDollarQueryOptions = true;
               opt.EnableQueryFeatures(20000);
               opt.Select().Expand().Filter();
            }
         );


         return services;
      }
   }
}