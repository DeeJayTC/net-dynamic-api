using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.APIGenerator.Data;

namespace TCDev.APIGenerator.Model
{
    public class EventHandler<T>
    {
        private readonly ApplicationDataService Data;
        public EventHandler(ApplicationDataService data)
        {
            Data = data;
        }
        
        
        
    }
}
