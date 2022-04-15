// TCDev.de 2022/03/16
// TCDev.APIGenerator.GraphQL.GenericGraphQLSchema.cs
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Reflection;

namespace TCDev.ApiGenerator.GraphQL;

public class GenericGraphQlSchema
{
   public GenericGraphQlSchema(IServiceProvider sp)
   {
      string[] assemblies =
      {
         Assembly.GetEntryAssembly()
            .FullName
      };
      foreach (var assembly in assemblies)
      {
      }
   }
}
