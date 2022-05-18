using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Hooks;
public interface IBeforeDelete<T> where T : class
{
    Task<bool> BeforeDelete(T item, IApplicationDataService<GenericDbContext, AuthDbContext> data);
}
