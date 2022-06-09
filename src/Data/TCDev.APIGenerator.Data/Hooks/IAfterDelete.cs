using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Hooks;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IAfterDelete<T, TEntityId> where T : class
   {
      Task<TEntityId> AfterDelete(T newItem, IApplicationDataService<GenericDbContext, AuthDbContext> data);
    }
}
