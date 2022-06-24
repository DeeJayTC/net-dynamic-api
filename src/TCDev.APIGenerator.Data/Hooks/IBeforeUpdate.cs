using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Hooks;

public interface IBeforeUpdate<T> where T : class
{
 Task<T> BeforeUpdate(T newItem, T oldItem, IApplicationDataService<GenericDbContext, AuthDbContext> data);
}
