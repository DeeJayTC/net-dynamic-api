using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;

namespace TCDev.APIGenerator.Hooks;

public interface IAfterCreate<T> where T : class
{
   Task<T> AfterCreate(T newItem, IApplicationDataService<GenericDbContext,AuthDbContext> data);
}
