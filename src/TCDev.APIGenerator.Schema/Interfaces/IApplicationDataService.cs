using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TCDev.APIGenerator.Events;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Hooks;

public interface IApplicationDataService<TGeneric,TAuth> where TGeneric : DbContext
{
    public TGeneric GenericDataContext { get; init; }
    public TAuth AuthDataContext { get; init; }
    public HttpContext Context { get; init; }
    
    public ICacheService CacheService { get; set; }
    public IMessageProducer MessageProducerService { get; set; }
}
