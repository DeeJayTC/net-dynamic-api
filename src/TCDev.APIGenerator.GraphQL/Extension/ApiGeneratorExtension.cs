// TCDev.de 2022/03/16
// TCDev.APIGenerator.GraphQL.ApiGeneratorExtension.cs
// https://www.github.com/deejaytc/dotnet-utils

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TCDev.ApiGenerator.Extension;

public static class ApiGeneratorExtension
{
   public static IServiceCollection AddApiGeneratorGraphQl(this IServiceCollection services, IConfiguration config, Assembly assembly)
   {
      services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });

      return services;
   }


   public static IApplicationBuilder UseApiGeneratorGraphQl(this IApplicationBuilder app)
   {
      return app;
   }


   public static IEndpointRouteBuilder UseGraphQlEndpoint(this IEndpointRouteBuilder endpoints)
   {
      endpoints.MapGraphQL();
      return endpoints;
   }
}
