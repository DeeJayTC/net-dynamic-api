// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.ApiGenerator.Attributes
{
   [AttributeUsage(AttributeTargets.Class)]
   public class GeneratedControllerAttribute : Attribute
   {
      /// <summary>
      ///    Attribute defining auto generated controller for the class
      /// </summary>
      /// <param name="route">The full base route for the class ie /myclass/ </param>
      /// <param name="requiredReadClaims"></param>
      /// <param name="requiredWriteClaims"></param>
      /// <param name="requiredRolesRead"></param>
      /// <param name="requiredRolesWrite"></param>
      /// <param name="fireEvents"></param>
      /// <param name="authorize"></param>
      /// <param name="cache"></param>
      /// <param name="cacheDuration"></param>
      public GeneratedControllerAttribute(
         string route,
         string[] requiredReadClaims = null,
         string[] requiredWriteClaims = null,
         string[] requiredRolesRead = null,
         string[] requiredRolesWrite = null,
         bool fireEvents = false,
         bool authorize = true,
         bool cache = false,
         int cacheDuration = 50000)
      {
         Route = route;
         Options = new GeneratedControllerAttributeOptions
         {
            RequiredReadClaims = requiredReadClaims, RequiredWriteClaims = requiredWriteClaims, Authorize = authorize, Cache = cache, CacheDuration = cacheDuration, FireEvents = fireEvents
         };
      }

      public string Route { get; set; }
      public GeneratedControllerAttributeOptions Options { get; set; }
   }
}