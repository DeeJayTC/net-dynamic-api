using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Model
{
    public class EventHandler<T>
    {
        private readonly IApplicationDataService Data;
        public EventHandler(IApplicationDataService data)
        {
            Data = data;
        }
        
        
        
    }
}
