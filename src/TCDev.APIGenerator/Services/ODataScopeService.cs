using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using TCDev.ApiGenerator.Attributes;
using TCDev.ApiGenerator.Interfaces;

namespace TCDev.APIGenerator.Services
{
    public class ODataScopeService<T, TId> where T : IObjectBase<TId>
    {
        private readonly AssemblyService assemblyData;
        public ODataScopeService(AssemblyService assemblyData)
        {
            this.assemblyData = assemblyData;
        }

        /// <summary>
        /// Get all scopes required for the given query
        /// walks along all $expand properties and checks all required scopes
        /// returns a list of all scopes required
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public List<string> GetRequestedScopes(ODataQueryOptions<T> options)
        {
            var scopes = new List<string>();
            var types = GetRequestedTypes(options);
            foreach (var type in types)
            {
                var attrs = Attribute.GetCustomAttributes(type);
                if (attrs.FirstOrDefault(p => p.GetType() == typeof(ApiAttribute)) is not ApiAttribute optionAttrib)
                    continue;

                if(optionAttrib.Options.RequiredReadScopes != null) scopes.AddRange(optionAttrib.Options.RequiredReadScopes);

            }

            return scopes;
        }

        /// <summary>
        /// Get all types requested in the OData query,
        /// walks along all $expand properties and returns all types requested
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public IEnumerable<Type> GetRequestedTypes(ODataQueryOptions<T> options)
        {
            if (options.SelectExpand.GetType()
                    .GetProperty("ProcessedSelectExpandClause",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.GetValue(options.SelectExpand) is SelectExpandClause selectedTypes)
            {
                var typesRequested = new List<Type>
                {
                    this.assemblyData.Types.FirstOrDefault(p => p.Name == options.Context.NavigationSource.Name)
                };
                foreach (ExpandedNavigationSelectItem selectItem in selectedTypes.SelectedItems)
                {
                    typesRequested.AddRange(GetTypes(selectItem).FindAll((x) => !typesRequested.Contains(x)));
                }

                return typesRequested;
            }

            return null;
        }


        private List<Type> GetTypes(ExpandedNavigationSelectItem item)
        {
            var types = new List<Type>
            {
                this.assemblyData.Types.FirstOrDefault(p => p.Name == item.NavigationSource.Name)
            };

            foreach (ExpandedNavigationSelectItem subItem in item.SelectAndExpand.SelectedItems)
            {
                types.AddRange(GetTypes(subItem).FindAll((x) => !types.Contains(x)));
            }

            return types;
        }

    }
}
