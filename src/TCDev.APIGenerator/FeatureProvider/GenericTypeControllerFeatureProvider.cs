// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using TCDev.APIGenerator;
using TCDev.APIGenerator.Attributes;

namespace TCDev
{
   public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
   {
        /// <summary>
        ///    Initiate the Controller generator
        /// </summary>
        /// <param name="types">Names of assemblies to search for classes</param>
        /// <param name="controllerType">Type of controller (normal / Odata) to use</param>
      public GenericTypeControllerFeatureProvider(List<Type> types, Type controllerType)
      {
         this.Types = types;
         this.controllerType = controllerType;
      }

      private List<Type> Types { get; }
      private Type controllerType { get; }

      public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
      {
        foreach (var candidate in Types)
        {
            // Ignore BaseController itself
            if (candidate.FullName != null && candidate.FullName.Contains("BaseController")) continue;

            // Generate type info for our runtime controller, assign class as T
            var propertyType = candidate.GetProperty("Id")?.PropertyType;
            if (propertyType == null) continue;

            var typeInfo = controllerType.MakeGenericType(candidate, propertyType).GetTypeInfo();
            feature.Controllers.Add(typeInfo);
        }
      }
   }
}