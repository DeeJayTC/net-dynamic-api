using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Middleware
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHttpContextAccessor accessor;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, IHttpContextAccessor accessor, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
            this.accessor = accessor;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error was ocurred during the process. Trace Identifier: {accessor.HttpContext.TraceIdentifier}.");

                await HandleExceptionMessageAsync(accessor.HttpContext, ex).ConfigureAwait(false);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception ex)
        {
            string response = JsonConvert.SerializeObject(new ValidationProblemDetails()
            {
                Title = "An error was occurred.",
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.Request.Path,
                Detail = ex.Message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          

            return context.Response.WriteAsync(response);
        }
    }

}
