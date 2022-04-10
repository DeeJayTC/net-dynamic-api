using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;

namespace ApiGeneratorSampleApI.Model
{

   [Api("/car", authorize: true)]
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
   }


   [Api("/carMakes")]
   public class Make : IObjectBase<Guid>
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [SwaggerIgnore]
      public Guid Id { get; set; } = Guid.NewGuid();
      public string Name { get; set; }

      public string Description { get; set; }
   }
}
