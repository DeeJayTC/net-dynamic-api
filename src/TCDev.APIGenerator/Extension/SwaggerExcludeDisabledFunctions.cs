using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Attributes;

namespace TCDev.APIGenerator.Extension
{
   public class ShowInSwaggerFilter : IDocumentFilter
   {
      public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
      {
         foreach (var contextApiDescription in context.ApiDescriptions)
         {
            var actionDescriptor = (ControllerActionDescriptor)contextApiDescription.ActionDescriptor;

            if (actionDescriptor.ControllerTypeInfo.FullName.Contains("TCDev.ApiGenerator.GenericController"))
            {

               var allowedMethods = actionDescriptor.ControllerTypeInfo.GetDeclaredProperty("methodsToGenerate");
               var customType = actionDescriptor.ControllerTypeInfo.GenericTypeArguments[0];
               if (customType != null)
               {
                  var attribute = customType.GetCustomAttributes(typeof(ApiAttribute), false);
                  var options = ((TCDev.ApiGenerator.Attributes.ApiAttribute)((TCDev.ApiGenerator.Attributes.ApiAttribute[])attribute)[0]).Options;
                  if (options != null)
                  {
                     if (options.Methods == ApiMethodsToGenerate.All) continue;

                     if (contextApiDescription.HttpMethod == "GET" && !options.Methods.HasFlag(ApiMethodsToGenerate.Get))
                     {
                        RemoveEndpoint(swaggerDoc, contextApiDescription);
                     }

                     if (contextApiDescription.HttpMethod == "POST" && !options.Methods.HasFlag(ApiMethodsToGenerate.Insert))
                     {
                        RemoveEndpoint(swaggerDoc, contextApiDescription);
                     }

                     if (contextApiDescription.HttpMethod == "PUT" && !options.Methods.HasFlag(ApiMethodsToGenerate.Update))
                     {
                        RemoveEndpoint(swaggerDoc, contextApiDescription);
                     }

                     if (contextApiDescription.HttpMethod == "DELETE" && !options.Methods.HasFlag(ApiMethodsToGenerate.Delete))
                     {
                        RemoveEndpoint(swaggerDoc, contextApiDescription);
                     }
                  }
               }
            }
         }
      }

      private static void RemoveEndpoint(OpenApiDocument swaggerDoc, Microsoft.AspNetCore.Mvc.ApiExplorer.ApiDescription contextApiDescription)
      {
         var key = "/" + contextApiDescription.RelativePath.TrimEnd('/');
         var operation = (OperationType)Enum.Parse(typeof(OperationType), contextApiDescription.HttpMethod, true);

         swaggerDoc.Paths[key].Operations.Remove(operation);

         // drop the entire route of there are no operations left
         if (!swaggerDoc.Paths[key].Operations.Any())
         {
            swaggerDoc.Paths.Remove(key);
         }
      }
   }
}
