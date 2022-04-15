using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IAfterDelete<T, TEntityId> where T : class
   {
      Task<TEntityId> AfterDelete(T newItem);
   }
}
