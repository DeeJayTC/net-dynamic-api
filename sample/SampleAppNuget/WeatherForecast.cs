using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;

namespace SampleAppNuget
{

   [Api("/simple")]
   public class WeatherForecast : IObjectBase<int>
   {
      public DateTime Date { get; set; }

      public int TemperatureC { get; set; }

      public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

      public string? Summary { get; set; }
      public int Id { get; set; }

   }
}