// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

namespace TCDev.ApiGenerator.Attributes
{
   /// <summary>
   ///    Configuration settings for generated controller behaviour
   /// </summary>
   public class ApiAttributeAttributeOptions
   {
      /// <summary>
      ///    Claims required for read access
      /// </summary>
      public string[] RequiredReadScopes { get; set; } = new string[0];

      /// <summary>
      ///    Claims required for write access
      /// </summary>
      public string[] RequiredWriteScopes { get; set; } = new string[0];

      /// <summary>
      ///    Wether authorized access is required or not
      /// </summary>
      public bool Authorize { get; set; } = false;

      /// <summary>
      ///    Cache responses
      /// </summary>
      public bool Cache { get; set; } = false;

      /// <summary>
      ///    Read/Write calls will fire RMQ Events
      /// </summary>
      public bool FireEvents { get; set; } = false;

      /// <summary>
      ///    Default cache duration
      /// </summary>
      public int CacheDuration { get; set; } = 50000;

      public ApiMethodsToGenerate Methods { get; set; } = ApiMethodsToGenerate.All;
   }
}