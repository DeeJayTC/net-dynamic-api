// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TCDev.ApiGenerator.Interfaces
{
   public interface IObjectBase<TId>
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [SwaggerSchema(ReadOnly = true)]
      TId Id { get; set; }
   }
}