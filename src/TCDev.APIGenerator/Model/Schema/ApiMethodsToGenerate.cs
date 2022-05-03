// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.ApiGenerator.Attributes
{

   [Flags]
   public enum ApiMethodsToGenerate
   {
      Get = 1,
      GetById = 2,
      Insert = 4,
      Update = 8,
      Delete = 16,
      All = Get | GetById | Delete | Update | Insert
   }
}