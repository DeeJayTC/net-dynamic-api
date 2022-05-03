// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TCDev.APIGenerator.Services;

namespace TCDev.ApiGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Class )]
    public class ApiAuthAttribute : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _assemblies = context.HttpContext.RequestServices.GetService(typeof(AssemblyService)) as AssemblyService;
            var _type = _assemblies.Types.FirstOrDefault(p => p.Name == 
                               ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName);

            if (_type == null) return;

            var attrs = Attribute.GetCustomAttributes(_type, typeof(ApiAttribute));
            if (attrs.FirstOrDefault(p => p.GetType() == typeof(ApiAttribute)) is ApiAttribute optionAttrib)
            {
                if (!optionAttrib.Options.Authorize) return;

                if (context.HttpContext.User.Identity != null && !context.HttpContext.User.Identity.IsAuthenticated)
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                throw new Exception($"Could not find ApiAttribute on Class: {_type.GetType()}");
            }

        }
    }
}