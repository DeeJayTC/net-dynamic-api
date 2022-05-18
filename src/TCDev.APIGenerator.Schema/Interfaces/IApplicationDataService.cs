using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TCDev.APIGenerator.Hooks;

public interface IApplicationDataService<TGeneric,TAuth> where TGeneric : DbContext
{
    public TGeneric GenericData { get; set; }
    public TAuth AuthData { get; set; }
    public HttpContext Context { get; set; }
}
