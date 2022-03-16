// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using System;
using System.Linq;
using System.Threading.Tasks;

namespace TCDev.ApiGenerator.Data
{
   public interface IGenericRespository<T, TEntityId> : IDisposable
   {
      IQueryable<T> Get();

      T Get(TEntityId id);

      Task<T> GetAsync(TEntityId id);

      void Create(T record);

      void Update(T record);

      void Delete(TEntityId id);

      int Save();

      Task<int> SaveAsync();
   }
}