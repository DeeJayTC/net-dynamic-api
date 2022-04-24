using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Data;
using TCDev.APIGenerator.Data;

namespace TCDev.ApiGenerator.Schema.Interfaces
{
   public interface IBeforeUpdate<T> where T : class
   {
     Task<T> BeforeUpdate(T newItem, T oldItem, ApplicationDataService data);
    }
}
