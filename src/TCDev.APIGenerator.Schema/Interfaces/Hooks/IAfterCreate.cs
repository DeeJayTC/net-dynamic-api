using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IAfterCreate<T> where T : class
   {
      Task<T> AfterCreate(T newItem);
   }
}
