// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

namespace TCDev.ApiGenerator.App
{
   public class WeatherForecast
   {
      public DateTime Date { get; set; }

      public int TemperatureC { get; set; }

      public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

      public string? Summary { get; set; }
   }
}