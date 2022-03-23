// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.ApiGenerator.Attributes
{

   [Flags]
   public enum ApiMethodsToGenerate
   {
      Get = 1,
      GetById = 2,
      Insert = 4,
      Update = 8,
      Delete = 16,
      All = Get | GetById | Delete | Update | Insert
   }


   [AttributeUsage(AttributeTargets.Class)]
   public class ApiAttribute : Attribute
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
      /// <param name="methods">The methods to generate for this endpoint</param>
      public ApiAttribute(
         string route,
         ApiMethodsToGenerate methods = ApiMethodsToGenerate.All,
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
         Options = new ApiAttributeAttributeOptions
         {
            RequiredReadClaims = requiredReadClaims, 
            RequiredWriteClaims = requiredWriteClaims, 
            Authorize = authorize, 
            Cache = cache, 
            CacheDuration = cacheDuration, 
            FireEvents = fireEvents,
            Methods = methods
         };
      }

      public string Route { get; set; }
      public ApiAttributeAttributeOptions Options { get; set; }
   }
}