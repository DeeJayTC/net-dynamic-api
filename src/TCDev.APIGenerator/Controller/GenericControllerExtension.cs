// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCDev.ApiGenerator.FeatureProvider.ApplicationParts;

namespace TCDev.ApiGenerator
{
   public static class GenericControllerExtensions
   {
      public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, Type genericControllerType,
         IEnumerable<Type> entityTypes)
      {
         mvcBuilder.ConfigureApplicationPartManager(manager => { manager.ApplicationParts.Add(new GenericControllerApplicationPart(genericControllerType, entityTypes)); });

         return mvcBuilder;
      }

      public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, Type genericControllerType,
         Type entityType)
      {
         mvcBuilder.ConfigureApplicationPartManager(manager => { manager.ApplicationParts.Add(new GenericControllerApplicationPart(genericControllerType, entityType)); });

         return mvcBuilder;
      }

      public static IMvcBuilder AddGenericControllers<TDbContext, TEntity>(this IMvcBuilder mvcBuilder,
         Type genericControllerType) where TDbContext : DbContext
      {
         var entityTypes = typeof(TDbContext)
            .GetProperties()
            .Select(p => p.PropertyType)
            .Where(pt => pt.IsGenericType
                         && pt.GetGenericTypeDefinition() == typeof(DbSet<>))
            .Select(pt => pt.GetGenericArguments()[0])
            .Where(t => typeof(TEntity).IsAssignableFrom(t)
                        && t.IsClass
                        && !t.IsAbstract);

         mvcBuilder.ConfigureApplicationPartManager(manager => { manager.ApplicationParts.Add(new GenericControllerApplicationPart(genericControllerType, entityTypes)); });

         return mvcBuilder;
      }
   }
}