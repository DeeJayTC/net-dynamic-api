// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;

namespace TCDev.ApiGenerator.Data
{
   public interface IGenericRespository<T, TEntityId> : IDisposable
   {
      IQueryable<T> Get();

      T Get(TEntityId id);

      Task<T> GetAsync(TEntityId id, ApplicationData data);

      void Create(T record, ApplicationData data);

      void Update(T record, T oldRecord, ApplicationData data);

      void Delete(TEntityId id, ApplicationData data);

      int Save();

      Task<int> SaveAsync();
   }
}