using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IAfterCreate<T> where T : class
   {
      //Task<T> AfterCreate(T newItem, ApplicationData data);
    }
}
