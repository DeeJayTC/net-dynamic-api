// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace TCDev.ApiGenerator.Attributes
{
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
   public class PatientAuthorizeAttribute : TypeFilterAttribute
   {
      public PatientAuthorizeAttribute() : base(typeof(AuthFilter))
      {
      }

      private class AuthFilter : IActionFilter
      {
         public void OnActionExecuted(ActionExecutedContext filterContext)
         {
            throw new NotImplementedException();
         }

         public void OnActionExecuting(ActionExecutingContext context)
         {
         }
      }
   }
}