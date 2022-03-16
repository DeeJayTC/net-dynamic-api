// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.ApiGenerator.Interfaces
{
   public interface ISoftDelete
   {
      string DeletedById { get; set; }
      DateTime Deleted { get; set; }
      bool IsDeleted { get; set; }
   }
}