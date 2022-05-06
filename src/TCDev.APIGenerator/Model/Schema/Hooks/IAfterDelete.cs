using System.Threading.Tasks;

namespace TCDev.ApiGenerator.Schema.Interfaces
{
   public interface IAfterDelete<T, TEntityId> where T : class
   {
      //Task<TEntityId> AfterDelete(T newItem, ApplicationData data);
    }
}
