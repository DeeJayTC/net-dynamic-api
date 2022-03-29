// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;
using TCDev.ApiGenerator.Schemes.Interfaces;
using TCDev.APIGenerator.Schema.Interfaces;

namespace ApiGeneratorSampleApI.Model
{
   [Api("/people", ApiMethodsToGenerate.All )]
   public class Person : Trackable, 
      IObjectBase<Guid>,
      IBeforeUpdate<Person>, // Before Update Hook
      IBeforeDelete<Person>, // BeforeDelete Hook
      IEntityTypeConfiguration<Person> // Configure Table Options yourself
   {
      public string Name { get; set; }


      public DateTime Date { get; set; }
      public string Description { get; set; }
      public int Age { get; set; }
      public Guid Id { get; set; }

      /// <summary>
      /// Before Delete Hook
      /// </summary>
      /// <param name="item"></param>
      /// <returns></returns>
      public Task<bool> BeforeDelete(Person item)
      {
         // NOOOO Don't delete me!
         return Task.FromResult(true);
      }

      /// <summary>
      /// Before Update Hook
      /// </summary>
      /// <param name="newPerson"></param>
      /// <param name="oldPerson"></param>
      /// <returns></returns>
      public Task<Person> BeforeUpdate(Person newPerson, Person oldPerson)
      {
         newPerson.Age = 333;

         return Task.FromResult(newPerson);
      }

      public void Configure(EntityTypeBuilder<Person> builder)
      {
         builder.ToTable("MyFancyTableName");
         //....all the other EF Core Options
      }
   }

}