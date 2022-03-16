// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using TCDev.ApiGenerator;
using TCDev.ApiGenerator.Attributes;

namespace TCDev.Controllers
{
   public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
   {
      /// <summary>
      ///    Initiate the Controller generator
      /// </summary>
      /// <param name="assemblies">Names of assemblies to search for classes</param>
      public GenericTypeControllerFeatureProvider(string[] assemblies)
      {
         Assemblies = assemblies;
      }

      private string[] Assemblies { get; }

      public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
      {
         foreach (var assembly in Assemblies)
         {
            var loadedAssembly = Assembly.Load(assembly);
            var customClasses = loadedAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

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
}