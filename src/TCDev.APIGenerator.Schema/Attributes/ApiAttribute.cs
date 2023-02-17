// TCDev.de 2022/04/10
// TCDev.APIGenerator.ApiAttribute.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TCDev.APIGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiAttribute : Attribute
    {
        /// <summary>
        ///    Attribute defining auto generated controller for the class
        /// </summary>
        /// <param name="route">The full base route for the class ie /myclass/ </param>
        /// <param name="requiredReadScopes"></param>
        /// <param name="requiredWriteScopes"></param>
        /// <param name="fireEvents"></param>
        /// <param name="authorize"></param>
        /// <param name="cache"></param>
        /// <param name="cacheDuration"></param>
        /// <param name="methods">The methods to generate for this endpoint</param>
        public ApiAttribute(
            string route,
            ApiMethodsToGenerate methods = ApiMethodsToGenerate.All,
            string[] requiredReadScopes = null,
            string[] requiredWriteScopes = null,
            bool fireEvents = false,
            bool authorize = false
            )
        {
            this.Route = route;
            this.Options = new ApiAttributeAttributeOptions
            {
                RequiredReadScopes = requiredReadScopes,
                RequiredWriteScopes = requiredWriteScopes,
                Authorize = authorize,
                FireEvents = fireEvents,
                Methods = methods
            };
        }

        public string Route { get; set; }
        public ApiAttributeAttributeOptions Options { get; set; }
    }
}
