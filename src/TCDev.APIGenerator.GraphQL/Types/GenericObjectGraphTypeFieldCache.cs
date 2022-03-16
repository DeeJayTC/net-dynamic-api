// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

//using GraphQL.Types;
//using Microsoft.Extensions.Caching.Memory;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TCDev.ApiGenerator.GraphQL
//{

//	public class GenericObjectGraphTypeCache : IGenericObjectGraphTypeCache
//    {
//        private IMemoryCache _cache;

//        public GenericObjectGraphTypeCache(IMemoryCache cache)
//        {
//            _cache = cache;
//        }

//        public bool TryGetFields(Type type, out IList<FieldType> fieldTypes)
//        {
//            return _cache.TryGetValue($"{type.FullName}.Fields", out fieldTypes);
//        }

//        public void AddFields(Type type, FieldType fieldType)
//        {
//            if (!_cache.TryGetValue<IList<FieldType>>($"{type.FullName}.Fields", out var fieldTypes))
//                fieldTypes = new List<FieldType>();

//            if (fieldTypes.Any(ft => ft.Name == fieldType.Name))
//                return;

//            fieldTypes.Add(fieldType);

//            _cache.Set($"{type.FullName}.Fields", fieldTypes);
//        }

//        public bool TryGetGraphType(Type type, out object graphType)
//        {
//            return _cache.TryGetValue(type.FullName, out graphType);
//        }

//        public void AddGraphType(Type type, object graphType)
//        {
//            _cache.Set(type.FullName, graphType);
//        }
//    }
//}

