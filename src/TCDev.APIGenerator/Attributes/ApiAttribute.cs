// TCDev.de 2022/04/10
// TCDev.APIGenerator.ApiAttribute.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TCDev.ApiGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiAttribute : Attribute
    {
        /// <summary>
        ///    Attribute defining auto generated controller for the class
        /// </summary>
        /// <param name="route">The full base route for the class ie /myclass/ </param>
        /// <param name="requiredReadClaims"></param>
        /// <param name="requiredWriteClaims"></param>
        /// <param name="requiredRolesRead"></param>
        /// <param name="requiredRolesWrite"></param>
        /// <param name="fireEvents"></param>
        /// <param name="authorize"></param>
        /// <param name="cache"></param>
        /// <param name="cacheDuration"></param>
        /// <param name="methods">The methods to generate for this endpoint</param>
        public ApiAttribute(
            string route,
            ApiMethodsToGenerate methods = ApiMethodsToGenerate.All,
            string[] requiredReadClaims = null,
            string[] requiredWriteClaims = null,
            string[] requiredRolesRead = null,
            string[] requiredRolesWrite = null,
            bool fireEvents = false,
            bool authorize = true,
            bool cache = false,
            int cacheDuration = 50000)
        {
            this.Route = route;
            this.Options = new ApiAttributeAttributeOptions
            {
                RequiredReadClaims = requiredReadClaims, 
                RequiredWriteClaims = requiredWriteClaims, 
                Authorize = authorize, 
                Cache = cache, 
                CacheDuration = cacheDuration, 
                FireEvents = fireEvents,
                Methods = methods
            };
        }

        public string Route { get; set; }
        public ApiAttributeAttributeOptions Options { get; set; }

    }
}
