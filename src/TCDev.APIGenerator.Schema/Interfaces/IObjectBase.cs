// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCDev.ApiGenerator.Attributes;

namespace TCDev.ApiGenerator.Interfaces
{
   public interface IObjectBase<TId>
   {
      [Key]
      TId Id { get; set; }
   }
}