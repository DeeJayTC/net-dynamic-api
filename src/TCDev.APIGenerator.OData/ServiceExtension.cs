using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Text.Json.Serialization;
using TCDev.APIGenerator.Extension;
using TCDev.APIGenerator.Schema.Exceptions;
using TCDev.APIGenerator.Services;

namespace TCDev.APIGenerator
{
    public static class ODataBuilder
    {
        public static IEdmModel GetEdmModel(AssemblyService service)
        {
            var builder = new ODataConventionModelBuilder();
            var entitySetMethod = typeof(ODataConventionModelBuilder).GetMethod(nameof(ODataConventionModelBuilder.EntitySet));
            foreach (var customType in service.Types)
            {
                builder.AddEntityType(customType);
                var genericEntitySetMethod = entitySetMethod.MakeGenericMethod(customType);
                genericEntitySetMethod.Invoke(builder, new object[] { customType.Name });
            }

            return builder.GetEdmModel();
        }

        public static ApiGeneratorServiceBuilder AddOData(
            this ApiGeneratorServiceBuilder builder, 
            Action<Microsoft.AspNetCore.OData.ODataOptions>? options = null)
        {

            builder.Services.AddSingleton(typeof(ODataScopeService<,>));

            if(builder.ApiGeneratorConfig == null)  throw new APIGeneratorSetupException("Please use AddConfig() first!");

            if(options != null)
            {
                builder.Services
                    .AddControllers()
                    .AddOData(options);
            } else
            {
                builder.Services
                    .AddControllers()

                    .AddOData(opt =>
                    {
                        opt.AddRouteComponents(builder.ApiGeneratorConfig.ODataOptions.OdataRoute, GetEdmModel(builder.AssemblyService));
                        opt.EnableNoDollarQueryOptions = builder.ApiGeneratorConfig.ODataOptions.EnableNoDollarQueryOptions;
                        opt.EnableQueryFeatures(20000)
                           .SetMaxTop(builder.ApiGeneratorConfig.ODataOptions.MaxTop)
                           .Count()
                           .SkipToken();

                        if (builder.ApiGeneratorConfig.ODataOptions.EnableFilter) opt.Filter();
                        if (builder.ApiGeneratorConfig.ODataOptions.EnableSelect) opt.Select();
                        if (builder.ApiGeneratorConfig.ODataOptions.EnableExpand) opt.Expand();
                        if (builder.ApiGeneratorConfig.ODataOptions.EnableOrderBy) opt.OrderBy();

                    })
                    .AddJsonOptions(o => {
                        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });
            }


            return builder;
        }




    }
}