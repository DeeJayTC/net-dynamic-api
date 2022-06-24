// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TCDev.APIGenerator.Attributes
{
   [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Enum)]
   public class SwaggerIgnoreAttribute : Attribute
   {
      public SwaggerIgnoreAttribute()
      {
      }
   }
}