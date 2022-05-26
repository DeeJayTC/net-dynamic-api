// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TCDev.APIGenerator.Attributes;

namespace TCDev.APIGenerator.Interfaces
{
    
    /// <summary>
    /// Base Interface for all APIs created by the API Generator
    /// Every type that's supposed to be a REST endpoint has to implement
    /// this interface. 
    /// </summary>
    /// <typeparam name="TId">The type of the ID field of the class, can be string, guid or int</typeparam>
   public interface IObjectBase<TId>
   {
      [Key]
      TId Id { get; set; }
   }
}