// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TCDev.ApiGenerator.FeatureProvider.ApplicationParts
{
   public class GenericControllerApplicationPart : ApplicationPart, IApplicationPartTypeProvider
   {
      public GenericControllerApplicationPart(Type genericControllerType, Type entityType)
      {
         GenericControllerType = genericControllerType;

         var entityTypes = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => entityType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

         Types = entityTypes
            .Select(et => GenericControllerType.MakeGenericType(et))
            .Select(cct => cct.GetTypeInfo())
            .ToArray();
      }

      public GenericControllerApplicationPart(Type genericControllerType, IEnumerable<Type> entityTypes)
      {
         GenericControllerType = genericControllerType;

         Types = entityTypes
            .Select(et => GenericControllerType.MakeGenericType(et))
            .Select(cct => cct.GetTypeInfo())
            .ToArray();
      }

      public override string Name => "GenericController";

      private Type GenericControllerType { get; }
      public IEnumerable<TypeInfo> Types { get; }
   }
}