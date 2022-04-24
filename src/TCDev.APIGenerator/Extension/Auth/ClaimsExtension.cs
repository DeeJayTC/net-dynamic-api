using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Extension.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetCacheId(this ClaimsPrincipal user)
        {
            var objectId = user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            var tenantId = user.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            var key = $"{objectId}-{user.GetJourneyId()}.{tenantId}";
            return key;
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            var hasObjectClaim = user.Claims.Any(p => p.Type == "name");
            return hasObjectClaim.ToString();
        }


        public static string GetObjectId(this ClaimsPrincipal user)
        {
            var hasObjectClaim = user.Claims.Any(p => p.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier");

            // Nothing found for "ObjectIdentifier -> Check OID instead"
            if (!hasObjectClaim)
            {
                hasObjectClaim = user.Claims.Any(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                if (hasObjectClaim) return user.Claims.FirstOrDefault(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            }

            if (!hasObjectClaim)
            {
                hasObjectClaim = user.Claims.Any(p => p.Type == "sub");
                if (hasObjectClaim) return user.Claims.FirstOrDefault(p => p.Type == "sub").Value;
            }

            if (hasObjectClaim) return user.Claims.FirstOrDefault(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/objectidentifier").Value;
            return string.Empty;
        }

        public static string GetClaimValue(this ClaimsPrincipal user, string claim)
        {
            var hasClaim = user.Claims.Any(p => p.Type == claim);
            if (hasClaim) return user.Claims.FirstOrDefault(p => p.Type == claim).Value;
            else return string.Empty;
        }


        public static string GetDetails(this ClaimsPrincipal user)
        {


            var hasObjectClaim = user.Claims.Any(p => p.Type == "http://schemas.microsoft.com/identity/claims/givenname");
            if (hasObjectClaim) return user.Claims.FirstOrDefault(p => p.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            return string.Empty;
        }


        public static string GetJourneyId(this ClaimsPrincipal user)
        {
            return user.FindFirst("http://schemas.microsoft.com/claims/authnclassreference").Value.Split('_')[2];
        }
    }
}
