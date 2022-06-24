// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCDev.APIGenerator.FeatureProvider.ApplicationParts;

namespace TCDev.APIGenerator
{
   public static class GenericControllerExtensions
   {
      public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, Type genericControllerType,
         IEnumerable<Type> entityTypes)
      {
         mvcBuilder.ConfigureApplicationPartManager(manager => { 
             manager.ApplicationParts.Add(
                 new GenericControllerApplicationPart(genericControllerType, entityTypes)); 
         });

         return mvcBuilder;
      }

      public static IMvcBuilder AddGenericControllers(this IMvcBuilder mvcBuilder, Type genericControllerType,
         Type entityType)
      {
         mvcBuilder.ConfigureApplicationPartManager(manager => { 
             manager.ApplicationParts.Add(
                 new GenericControllerApplicationPart(genericControllerType, entityType)); 
         });
            
         return mvcBuilder;
      }

        
      public static bool IsDBSet(Type pt)
      {
         return pt.IsGenericType && pt.GetGenericTypeDefinition() == typeof(DbSet<>);
      }
        
      public static bool IsAssignableFrom<TEntity>(Type t)
      {
         return typeof(TEntity).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract;
      }

      public static IMvcBuilder AddGenericControllers<TDbContext, TEntity>(
          this IMvcBuilder mvcBuilder,
          Type genericControllerType) where TDbContext : DbContext
      {
            var entityTypesList = typeof(TDbContext)
               .GetProperties()
                   .Select(p => p.PropertyType)
                       .Where(pt => IsDBSet(pt))
                           .Select(pt => pt.GetGenericArguments()[0]);
            
            entityTypesList = entityTypesList        
                .Where(t => IsAssignableFrom<TEntity>(t))
                   .ToList();

         mvcBuilder.ConfigureApplicationPartManager(manager => {
             manager.ApplicationParts.Add(
                 new GenericControllerApplicationPart(genericControllerType, entityTypesList)); 
         });

         return mvcBuilder;
      }
   }
}