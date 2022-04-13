using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TCDev.ApiGenerator
{
    public static class ScopeValidator
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