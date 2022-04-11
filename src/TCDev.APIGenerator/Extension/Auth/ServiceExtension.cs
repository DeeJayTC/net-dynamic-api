using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace TCDev.APIGenerator.Identity
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApiGeneratorIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            string domain = $"https://{configuration["Auth0:Domain"]}/";
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://structures.eu.auth0.com/";
                    options.Audience = "https://www.smoower.com";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            return services;
        }

        public static IApplicationBuilder UseApiGeneratorAuthentication(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }


    }
}