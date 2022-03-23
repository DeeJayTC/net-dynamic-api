// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;
using TCDev.ApiGenerator.Schemes.Interfaces;
using TCDev.APIGenerator.Schema.Interfaces;

namespace ApiGeneratorSampleApI.Model
{
   [Api("/people", 
      ApiMethodsToGenerate.Insert | 
      ApiMethodsToGenerate.Update | 
      ApiMethodsToGenerate.Delete)
   ]
   public class Person : Trackable, 
      IObjectBase<Guid>, 
      IEventDelegates<Person>
   {
      public string Name { get; set; }
      public DateTime Date { get; set; }
      public string Description { get; set; }
      public int Age { get; set; }

      public Guid Id { get; set; }

      public async Task<Person> AfterUpdate(Person item)
      {
         item.Age = 333;

         return item;
      }

      public Task<Person> BeforeUpdate(Person item)
      {
         throw new NotImplementedException();
      }
   }

}