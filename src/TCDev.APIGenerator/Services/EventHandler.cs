using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Hooks;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Model
{
    public class EventHandler<T>
    {
        private readonly IApplicationDataService<GenericDbContext, AuthDbContext> Data;
        public EventHandler(IApplicationDataService<GenericDbContext, AuthDbContext> data)
        {
            Data = data;
        }
        
        
        
    }
}
