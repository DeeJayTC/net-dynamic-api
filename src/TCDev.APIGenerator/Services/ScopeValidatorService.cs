using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TCDev.APIGenerator
{
    public static class ScopeValidatorService
    {
        public static bool ValidateScopes(this HttpContext context, IEnumerable<string> compareScopes, string resource)
        {
            var userScopes = context.User.Claims
                .FirstOrDefault(p => p.Type == "scope" || p.Type == "scp").Value
                .Split(" ")
                .ToArray();

            return userScopes.All(compareScopes.Contains);
        }
    }
}