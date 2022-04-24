using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.APIGenerator.Model;

namespace TCDev.APIGenerator.Extension
{
    public static class ContextExtension
    {
        public static IAppUser GetUser(this HttpContext context)
        {
            if (context == null) return null;
            return (IAppUser)context.Items["appUser"];
        }

        public static void SetUser(this HttpContext context, IAppUser user)
        {
            context.Items["appUser"] = user;
        }

        public static Tenant GetTenant(this HttpContext context)
        {
            if (context == null) return null;
            return (Tenant)context.Items["appTenant"];
        }

        public static void SetTenant(this HttpContext context, Tenant user)
        {
            context.Items["appTenant"] = user;
        }
    }
}
