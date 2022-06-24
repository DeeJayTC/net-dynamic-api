using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Hooks;

public interface IBeforeCreate<T> where T : class
{
      Task<T> BeforeCreate(T newItem, IApplicationDataService<GenericDbContext, AuthDbContext> data);
}
