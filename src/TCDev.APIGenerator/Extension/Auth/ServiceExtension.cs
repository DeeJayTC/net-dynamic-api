using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TCDev.ApiGenerator;

namespace TCDev.APIGenerator.Identity
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApiGeneratorIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ApiGeneratorConfig(configuration);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = config.IdentityOptions.Authority;
                    options.Audience = config.IdentityOptions.Audience;
                    options.RequireHttpsMetadata = false;
                    options.MetadataAddress = config.IdentityOptions.MetaDataUri;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = config.IdentityOptions.ValidateIssuer,
                        ValidateLifetime = config.IdentityOptions.ValidateLifetime,
                        ValidateIssuerSigningKey = config.IdentityOptions.ValidateIssuerSigningKey,
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