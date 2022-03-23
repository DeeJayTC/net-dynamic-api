// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Reflection;
using EFCore.AutomaticMigrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using TCDev.ApiGenerator.Data;
using TCDev.ApiGenerator.Extension;
using TCDev.APIGenerator.Extension;

namespace TCDev.ApiGenerator
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
         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

         services.AddControllers();


         // Add the API Generator Services, point to the assembly where the classes are you want to use
         services.AddApiGeneratorServices(Configuration, Assembly.GetExecutingAssembly());
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GenericDbContext db)
      {
         db.MigrateToLatestVersion(new DbMigrationsOptions
            {
               AutomaticMigrationsEnabled = true, AutomaticMigrationDataLossAllowed = true
            }
         );

         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseApiGenerator();

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints => {
            endpoints.UseApiGenerator();
            endpoints.MapControllers(); 
         });
      }
   }
}