// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Microsoft.AspNetCore.Mvc;

namespace TCDev.ApiGenerator.App.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class WeatherForecastController : ControllerBase
   {
      public WeatherForecastController(ILogger<WeatherForecastController> logger)
      {
         _logger = logger;
      }

      private readonly ILogger<WeatherForecastController> _logger;

      private static readonly string[] Summaries =
      {
         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
      };

      [HttpGet(Name = "GetWeatherForecast")]
      public IEnumerable<WeatherForecast> Get()
      {
         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
               Date = DateTime.Now.AddDays(index), TemperatureC = Random.Shared.Next(-20, 55), Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
      }
   }
}