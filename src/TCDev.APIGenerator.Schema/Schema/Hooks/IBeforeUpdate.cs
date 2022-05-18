using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Data;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IBeforeUpdate<T> where T : class
   {
     Task<T> BeforeUpdate(T newItem, T oldItem, ApplicationDataService data);
    }
}
