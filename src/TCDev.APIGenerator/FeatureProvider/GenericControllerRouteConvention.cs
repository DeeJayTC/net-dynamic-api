// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using TCDev.ApiGenerator.Attributes;

namespace TCDev.Controllers
{

   /// <summary>
   ///    Applies route conventions to allow routes for auto generated controllers
   ///    One of the main pieces to make the magic work.
   /// </summary>
   public class GenericControllerRouteConvention : IControllerModelConvention
   {
      public void Apply(ControllerModel controller)
      {
          if (!controller.ControllerType.IsGenericType) return;

          var genericType = controller.ControllerType.GenericTypeArguments[0];
          var customNameAttribute = genericType.GetCustomAttribute<ApiAttribute>();
          controller.ControllerName = genericType.Name;

          if (customNameAttribute?.Route == null) return;

          if (controller.Selectors.Count > 0)
          {
              var currentSelector = controller.Selectors[0];
              currentSelector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route));
          }
          else
          {
              controller.Selectors.Add(new SelectorModel
              {
                  AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(customNameAttribute.Route))
              });
          }
      }
   }
}