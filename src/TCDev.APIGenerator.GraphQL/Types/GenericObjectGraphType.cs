// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

//using GraphQL;
//using GraphQL.Types;
//using TCDev.ApiGenerator.Interfaces;
//using System;
//using System.Linq;
//using System.Reflection;

//namespace TCDev.ApiGenerator.GraphQL
//{
//    public class GenericObjectGraphType<T, TIdType> : ObjectGraphType<T> where T : class, IObjectBase<TIdType>
//    {
//		public GenericObjectGraphType()
//        {
//            var properties = typeof(T)
//                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
//                .Where(p => p.PropertyType.GetTypeInfo().IsValueType
//                    || p.PropertyType == typeof(string));

//            foreach (var propertyInfo in properties)
//            {
//                try
//                {
//                    var graphType = propertyInfo.PropertyType.GetGraphTypeFromType(propertyInfo.PropertyType.IsNullable());
//                    Field(graphType, propertyInfo.Name);
//                }
//                catch
//                {
//                    Field<StringGraphType>(propertyInfo.Name,
//                        resolve: context => context.Source.GetPropertyValue(propertyInfo.PropertyType).ToString());
//                }
//            }
//        }
//    }
//}

