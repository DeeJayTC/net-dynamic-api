// TCDev.de 2022/03/16
// TCDev.APIGenerator.GraphQL.GraphQLAttribute.cs
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.ApiGenerator.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class GraphQlAttribute : Attribute
{
   public ApiAttributeAttributeOptions Options { get; set; }

   /// <summary>
   ///    Attribute defining auto generated controller for the class
   /// </summary>
   /// <param name="route">The full base route for the class ie /myclass/ </param>
   /// <param name="fireEvents"></param>
   /// <param name="authorize"></param>
   /// <param name="cache"></param>
   /// <param name="cacheDuration"></param>
   public GraphQlAttribute(
      bool fireEvents = false,
      bool authorize = true,
      bool cache = false,
      int cacheDuration = 50000)
   {
      this.Options = new ApiAttributeAttributeOptions
      {
         Authorize = authorize, Cache = cache, CacheDuration = cacheDuration, FireEvents = fireEvents
      };
   }
}
