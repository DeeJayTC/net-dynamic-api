using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Data;

namespace TCDev.ApiGenerator.Schema.Interfaces
{
   public interface IAfterCreate<T> where T : class
   {
      //Task<T> AfterCreate(T newItem, ApplicationData data);
    }
}
