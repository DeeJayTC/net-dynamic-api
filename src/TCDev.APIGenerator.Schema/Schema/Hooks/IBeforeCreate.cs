using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Data;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IBeforeCreate<T> where T : class
   {
      Task<T> BeforeCreate(T newItem, ApplicationDataService data);
    }
}
