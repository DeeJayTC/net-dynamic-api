// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using TCDev.ApiGenerator.App.Middleware;

namespace TCDev.ApiGenerator.App
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddControllers();
         services.AddEndpointsApiExplorer();
         services.AddSwaggerGen();
         services.AddSpaStaticFiles(o => o.RootPath = "Client/dist");
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         app.UseSwagger();
         app.UseSwaggerUI();

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();

            //endpoints.MapToVueCliProxy(
            //    "{*path}",
            //    new SpaOptions { SourcePath = "Client" },
            //    npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
            //    regex: "Compiled successfully",
            //    forceKill: true,
            //    wsl: false // Set to true if you are using WSL on windows. For other operating systems it will be ignored
            // );
         });


         app.UseSpa(spa =>
         {
            spa.Options.SourcePath = "Client";
            spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            {
               RequestPath = "/Client/dist", ServeUnknownFileTypes = false
            };
            spa.Options.DefaultPage = "/Client/dist/index.html";

            if (env.IsDevelopment()) spa.UseVueDevelopmentServer();
         });
      }
   }
}