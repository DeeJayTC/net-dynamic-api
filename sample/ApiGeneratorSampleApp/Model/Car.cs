using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCDev.APIGenerator.Attributes;
using TCDev.APIGenerator.Interfaces;

namespace ApiGeneratorSampleApI.Model
{

    [Api("/car")]
    public class Car : IObjectBase<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();


        [EmailAddress]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public Make? Make { get; set; }

        public Model? Model { get; set; }
    }


    [Api("/carMakes",
        authorize: true,
        requiredReadScopes: new string[] { "make.read" },
        requiredWriteScopes: new string[] { "make.write" })]
    public class Make : IObjectBase<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public string Description { get; set; }


        public Model? Model { get; set; }
    }



    [Api("/carModel",
        authorize: true,
        requiredReadScopes: new string[] { "model.read" },
        requiredWriteScopes: new string[] { "model.write" })]
    public class Model : IObjectBase<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public string Description { get; set; }
    }

}
