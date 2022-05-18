// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

namespace TCDev.APIGenerator.Interfaces
{
   public interface IHasQueryFields
   {
      string[] QueryFields { get; }
   }
}