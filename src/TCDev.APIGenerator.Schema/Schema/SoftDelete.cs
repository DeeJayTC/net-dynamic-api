// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.ApiGenerator.Schemes
{
   public abstract class SoftDelete
   {
      public string DeletedById { get; set; }
      public DateTime Deleted { get; set; }
      public bool IsDeleted { get; set; }
   }
}