// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Caching
{
   public interface ICacheService<T>
   {
      public Task<bool> AddAllAsync(IList<Tuple<string, T>> items, DateTimeOffset offset);
      public Task<bool> AddAsync(T item, string cacheKey, DateTimeOffset offset);
      public Task<T> GetAsync(string cacheKey);
      public Task<IDictionary<string, T>> GetAllAsync<T>(IEnumerable<string> cacheKeys);
      public Task<bool> RemoveAsync(string cacheKey);
      public Task<long> RemoveAllAsync(IEnumerable<string> cacheKeys);
   }
}