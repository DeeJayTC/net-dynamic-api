// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;
using TCDev.ApiGenerator.Schemes.Interfaces;

namespace ApiGeneratorSampleApI.Model
{
   [GeneratedController("/people")]
   public class Person : Trackable, IObjectBase<Guid>
   {
      public string Name { get; set; }
      public DateTime Date { get; set; }
      public string Description { get; set; }
      public int Age { get; set; }

      public IEnumerable<PersonLink> Links { get; set; }
      public Guid Id { get; set; }
   }

   [GeneratedController("/peopleLink")]
   public class PersonLink : IObjectBase<Guid>
   {
      public string Name { get; set; }
      public Guid Id { get; set; }
   }
}