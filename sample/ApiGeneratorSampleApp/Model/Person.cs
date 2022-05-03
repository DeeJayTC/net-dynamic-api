// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Data;
using TCDev.ApiGenerator.Interfaces;
using TCDev.ApiGenerator.Schema.Interfaces;

namespace ApiGeneratorSampleApI.Model
{
    //[Api("/people")]
    //public class Person : IObjectBase<Guid>, IBeforeCreate<Person>
    //{
    //  public string Name { get; set; }
    //  public DateTime Date { get; set; }
    //  public string Description { get; set; }

    //  [Auth(AllowedRoles = new string[] { "admin" })]
    //  public int Age { get; set; }


    //  public Guid Id { get; set; }

    //    public Task<Person> BeforeCreate(Person newItem, GenericDbContext db, HttpContext context)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    [Api("/students")]
    public class Student : IObjectBase<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void BeforeDelete(Student student)
        {
            // Before Delete hook to make custom validations
        }

    }

    [Api("/teachers")]
    public class Teacher : IObjectBase<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public void BeforeCreate(Teacher newTeacher)
        {
            // Before Create hook to make custom validations
        }
    }

    [Api("/courses")]
    public class Course : IObjectBase<int>
    {
        public int Id { get; set; }
        public List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
        public List<DateTime> Schedule { get; set; }
    }


}