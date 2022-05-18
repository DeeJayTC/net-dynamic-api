using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Hooks;

   public interface IAfterUpdate<T> where T : class
   {
        Task<T> AfterUpdate(T newItem, T oldItem, IApplicationDataService<GenericDbContext, AuthDbContext> data);
   }
