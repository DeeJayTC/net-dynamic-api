using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Data;
using TCDev.APIGenerator.Data;

namespace TCDev.ApiGenerator.Schema.Interfaces
{
   public interface IBeforeCreate<T> where T : class
   {
      Task<T> BeforeCreate(T newItem, ApplicationDataService data);
    }
}
