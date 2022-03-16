// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TCDev.ApiGenerator.Extension
{
   public static class ApiGeneratorExtension
   {
      public static IServiceCollection AddApiGeneratorGraphQL(this IServiceCollection services, IConfiguration config, Assembly assembly)
      {
         services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });

         return services;
      }


      public static IApplicationBuilder UseAPIGeneratorGraphQL(this IApplicationBuilder app)
      {
         return app;
      }


      public static IEndpointRouteBuilder UseGraphQLEndpoint(this IEndpointRouteBuilder endpoints)
      {
         endpoints.MapGraphQL();
         return endpoints;
      }
   }
}