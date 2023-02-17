

using DemoAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCDev.APIGenerator.Attributes;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Hooks;
using TCDev.APIGenerator.Interfaces;

namespace DemoAPI
{

    [Api("/people", ApiMethodsToGenerate.All, authorize:true)]
    public class Person : IObjectBase<Guid>, IBeforeCreate<Person>
    {
        public Guid Id { get; set; } = new Guid();

        public string Name { get; set; }

        public string Job { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public Task<Person> BeforeCreate(Person newItem, IApplicationDataService<GenericDbContext, AuthDbContext> data)
        {
            return Task.Run(async () =>
            {


                return newItem;
            });
        }
    }

}
