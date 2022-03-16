// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Reflection;

namespace TCDev.ApiGenerator.GraphQL
{
   public class GenericGraphQLSchema
   {
      public GenericGraphQLSchema(IServiceProvider sp)
      {
         string[] assemblies = {Assembly.GetEntryAssembly().FullName};
         foreach (var assembly in assemblies)
         {
         }
      }
   }
}