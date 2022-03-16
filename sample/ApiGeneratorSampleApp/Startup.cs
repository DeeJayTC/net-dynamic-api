// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

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
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1",
               new OpenApiInfo
               {
                  Title = "TCDev.ApiGenerator", Version = "v1", Description = "Sample for TCDev API Generator"
               });
            c.IncludeXmlComments("ApiGeneratorSampleApp.xml", true);
         });

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
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TCDev.ApiGenerator v1"));
         }


         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthentication();
         app.UseAuthorization();

         app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
      }
   }
}