using GraphQL.Types;
using Maximago.ApiGenerator.Attributes;
using Maximago.ApiGenerator.Interfaces;
using Maximago.ApiGenerator.Schemes.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGeneratorSampleApI.Model
{

    [GeneratedController( route: "/people2" )]
    public class PersonAutoMode : IObjectBase<Guid>
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }


    [GeneratedController(
        route: "/people",
        authorize: false
    )]
    public class Person :
        IObjectBase<Guid>,
        IEntityTypeConfiguration<Person>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Configure(EntityTypeBuilder<Person> builder)
        {
           //default stuff if nothing special
        }
    }
}
