//// TCDev 2022/03/16
//// Apache 2.0 License
//// https://www.github.com/deejaytc/dotnet-utils

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Hosting;

//namespace TCDev.ApiGenerator
//{
//   [ApiController]
//   [Route("/manage")]
//   public class ManageController : Controller
//   {
//      public ManageController(IHostApplicationLifetime applicationLife)
//      {
//         lifetimeHandler = applicationLife;
//      }

//      private readonly IHostApplicationLifetime lifetimeHandler;

//      [HttpGet("/manage/reboot")]
//      public void Restart()
//      {
//         lifetimeHandler.StopApplication();
//      }
//   }
//}