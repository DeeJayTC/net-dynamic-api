// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Innofactor.EfCoreJsonValueConverter;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCDev.APIGenerator.Attributes;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Interfaces;
using TCDev.APIGenerator.Schema.Interfaces;

namespace ApiGeneratorSampleApI.Model
{

    [Api("/people", ApiMethodsToGenerate.All)]
    public class Person : IObjectBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
    }


    [Api("/departments", ApiMethodsToGenerate.All)]
    public class Department : IObjectBase<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Person> People { get; set; }

    }

}