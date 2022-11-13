using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Middleware
{
    public static class RateLimitting
    {
        private static readonly string Policy = "DefaultPolicy";

        public static IServiceCollection AddRateLimiting (this IServiceCollection services)
        {
            return services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.AddPolicy(Policy, context =>
                {

                    return RateLimitPartition.GetTokenBucketLimiter(id, key =>
                    {
                        return new()
                        {
                            ReplenishmentPeriod = TimeSpan.FromSeconds(10),
                            AutoReplenishment = true,
                            TokenLimit = 100,
                            TokensPerPeriod = 100,
                            QueueLimit = 100,
                        };
                    });
                });
            });
        }

        public static IEndpointConventionBuilder RequirePerUserRateLimit (this IEndpointConventionBuilder builder)
        {
            return builder.RequireRateLimiting(Policy);
        }

    }

}
