using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TCDev.APIGenerator.Events;
using TCDev.APIGenerator.Hooks;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Data
{
    public class ApplicationDataService<GenericDbContext, AuthDbContext> : IApplicationDataService<GenericDbContext, AuthDbContext> where GenericDbContext : DbContext
    {
        public GenericDbContext GenericDataContext { get; init; }
        public AuthDbContext AuthDataContext { get; init; }
        public HttpContext Context { get; init; }
        
        public ICacheService CacheService { get; set; }
        public IMessageProducer MessageProducerService { get; set; }

        public ApplicationDataService(GenericDbContext genericData, AuthDbContext authData, IHttpContextAccessor contextAccessor)
        {
            GenericDataContext = genericData;
            AuthDataContext = authData;
            Context = contextAccessor.HttpContext;

        }
    }
}
