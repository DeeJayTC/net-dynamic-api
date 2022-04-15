// TCDev.de 2022/04/15
// TCDev.APIGenerator.IgnoreODataQueryOptionOperationFilter.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TCDev.APIGenerator.Extension
{
    public class IgnoreODataQueryOptionOperationFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            context.ApiDescription.ParameterDescriptions.ToList()
                .ForEach(x =>
                {
                    if (x.Name == "ODataOpts")
                    {
                        if (operation.Parameters.Any(x => x.Name == "ODataOpts"))
                        {
                            try
                            {
                                operation.Parameters.Remove(operation.Parameters.Single(p => x.Name == "ODataOpts"));
                            }
                            catch
                            {

                            }
 
                        }
                    }

                });

        }
    }
}
