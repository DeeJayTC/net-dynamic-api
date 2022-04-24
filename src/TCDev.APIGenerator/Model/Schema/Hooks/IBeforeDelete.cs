using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Data;
using TCDev.APIGenerator.Data;

namespace TCDev.ApiGenerator.Schema.Interfaces
{
   public interface IBeforeDelete<T> where T : class
   {
      Task<bool> BeforeDelete(T item, ApplicationDataService data);
    }
}
