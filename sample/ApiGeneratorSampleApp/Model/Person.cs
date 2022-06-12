

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

    [Api("/people", ApiMethodsToGenerate.All)]
    public class Person : IObjectBase<Guid>, IAfterCreate<Person>, IBeforeCreate<Person>
    {
        public Guid Id { get; set; } = new Guid();

        public string Name { get; set; }

        public string Job { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }

        public Task<Person> AfterCreate(Person newItem, IApplicationDataService<GenericDbContext, AuthDbContext> data)
        {

            return Task.FromResult(newItem);
        }

        public Task<Person> BeforeCreate(Person newItem, IApplicationDataService<GenericDbContext, AuthDbContext> data)
        {
            newItem.Email = "hallo@hallo.de";

            return Task.FromResult(newItem);
        }
    }

}

[Api("/companies", ApiMethodsToGenerate.All)]
public class Company : IObjectBase<Guid>
{
    public Guid Id { get; set; } = new Guid();

    public string Name { get; set; }

    public string Email { get; set; }

    public string Image { get; set; }

    public List<Person>? People { get; set; }

    public string Address { get; set; }
    public string Country { get; set; }
}