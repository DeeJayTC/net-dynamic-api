using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Data;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IBeforeDelete<T> where T : class
   {
      Task<bool> BeforeDelete(T item, ApplicationDataService data);
    }
}
