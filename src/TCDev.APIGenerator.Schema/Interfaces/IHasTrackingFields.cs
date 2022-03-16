// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;

namespace TCDev.ApiGenerator.Interfaces
{
   public interface IHasTrackingFields
   {
      DateTime Created { get; set; }
      DateTime? LastModified { get; set; }
      string? LastModifiedById { get; set; }
      string CreatedById { get; set; }
   }
}