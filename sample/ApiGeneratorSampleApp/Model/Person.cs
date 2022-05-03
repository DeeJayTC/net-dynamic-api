// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Data;
using TCDev.ApiGenerator.Interfaces;
using TCDev.ApiGenerator.Schema.Interfaces;

namespace ApiGeneratorSampleApI.Model
{
    [Api("/people")]
    public class Person : IObjectBase<Guid>, IBeforeCreate<Person>
    {
      public string Name { get; set; }
      public DateTime Date { get; set; }
      public string Description { get; set; }
      public int Age { get; set; }
      public Guid Id { get; set; }

        public Task<Person> BeforeCreate(Person newItem, GenericDbContext db, HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}