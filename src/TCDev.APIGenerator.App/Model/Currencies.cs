// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

namespace TCDev.ApiGenerator.App.Model
{
   [GeneratedController("/config/currencies")]
   public class Currency
   {
      public string Label { get; set; }
      public string CurrencyCode { get; set; }
      public int DecimalDigits { get; set; }
      public string DecimalSeperator { get; set; }
      public string CurrencySymbol { get; set; }
      public string CurrencySymbolNumberOfSpaces { get; set; }
      public string CurrencySymbolPosition { get; set; }
   }
}