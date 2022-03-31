using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;

namespace ApiGeneratorSampleApI.Model
{

   [Api("/car")]
   public class Car : IObjectBase<Guid>
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [SwaggerSchema(ReadOnly = true)]
      [SwaggerIgnore]
      public Guid Id { get; set; } = Guid.NewGuid();


      [SwaggerSchema(ReadOnly = true)]
      public string Name { get; set; }
   }
}
