using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IBeforeDelete<T> where T : class
   {
      Task<bool> BeforeDelete(T item);
   }
}
