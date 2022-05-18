// TCDev 2022/03/16
// Apache 2.0 License
// https://www.github.com/deejaytc/dotnet-utils

using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Hooks;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Data
{
   public interface IGenericRespository<T, TEntityId> : IDisposable
   {
      IQueryable<T> Get();

      T Get(TEntityId id);

      Task<T> GetAsync(TEntityId id, IApplicationDataService<GenericDbContext, AuthDbContext> data);

      void Create(T record, IApplicationDataService<GenericDbContext, AuthDbContext> data);

      void Update(T record, T oldRecord, IApplicationDataService<GenericDbContext, AuthDbContext> data);

      void Delete(TEntityId id, IApplicationDataService<GenericDbContext, AuthDbContext> data);

      int Save();

      Task<int> SaveAsync();
   }
}