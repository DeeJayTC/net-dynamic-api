using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IBeforeUpdate<T> where T : class
   {
     Task<T> BeforeUpdate(T newItem, T oldItem);
   }
}
