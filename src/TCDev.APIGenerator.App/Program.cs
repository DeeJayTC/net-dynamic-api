// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using TCDev.ApiGenerator.App;

public class Program
{
   public static void Main(string[] args)
   {
      CreateHostBuilder(args).Build().Run();
   }

   public static IHostBuilder CreateHostBuilder(string[] args)
   {
      return Host.CreateDefaultBuilder(args)
         .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
   }
}