// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using TCDev.ApiGenerator;
using TCDev.ApiGenerator.Attributes;

namespace TCDev.Controllers
{
   public class GenericAssemblyControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
   {
      /// <summary>
      ///    Initiate the Controller generator
      /// </summary>
      /// <param name="assemblies">Names of assemblies to search for classes</param>
      public GenericAssemblyControllerFeatureProvider(Assembly[] assemblies)
      {
         this.Assemblies = assemblies;
      }

      private Assembly[] Assemblies { get; }

      public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
      {
         foreach (var assembly in Assemblies)
         {
            var customClasses = assembly.GetExportedTypes().Where(x => x.GetCustomAttributes<ApiAttribute>().Any());

            foreach (var candidate in customClasses)
            {
               // Ignore BaseController itself
               if (candidate.FullName != null && candidate.FullName.Contains("BaseController")) continue;

               // Generate type info for our runtime controller, assign class as T
               var propertyType = candidate.GetProperty("Id")?.PropertyType;
               if (propertyType == null) continue;
               var typeInfo = typeof(GenericController<,>).MakeGenericType(candidate, propertyType).GetTypeInfo();

               // Finally add the new controller via FeatureProvider ->
               feature.Controllers.Add(typeInfo);
            }
         }
      }
   }


   public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
   {
      /// <summary>
      ///    Initiate the Controller generator
      /// </summary>
      /// <param name="types">Names of assemblies to search for classes</param>
      public GenericTypeControllerFeatureProvider(List<Type> types)
      {
         this.Types = types;
      }

      private List<Type> Types { get; }

      public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
      {
         foreach (var type in this.Types)
         {
            // Ignore BaseController itself
            if (type.FullName != null && type.FullName.Contains("BaseController")) continue;

            // Generate type info for our runtime controller, assign class as T
            var propertyType = type.GetProperty("Id")?.PropertyType;
            if (propertyType == null) continue;
            var typeInfo = typeof(GenericController<,>).MakeGenericType(type, propertyType).GetTypeInfo();

            // Finally add the new controller via FeatureProvider ->
            feature.Controllers.Add(typeInfo);
         }
      }
   }
}