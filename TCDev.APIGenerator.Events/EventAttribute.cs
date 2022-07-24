using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Events
{
    [Flags]
    public enum Events
    {
        Created = 1,
        Updated = 2,
        Deleted = 4,
        All = Created
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class EventAttribute : Attribute
    {

        public Events events;
        public string routingKey;
        
        public EventAttribute(
            Events events,
            string routingKey = ""
            )
        {
            this.events = events;
            this.routingKey = routingKey;
        }
    }



}

