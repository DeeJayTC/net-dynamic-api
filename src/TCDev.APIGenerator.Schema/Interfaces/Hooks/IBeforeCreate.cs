using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IBeforeCreate<T> where T : class
   {
      Task<T> BeforeCreate(T newItem);
   }
}
