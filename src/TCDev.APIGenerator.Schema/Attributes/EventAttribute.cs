using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Events
{

    [Flags]
    public enum AMQPEvents
    {
        Created = 1,
        Updated = 2,
        Deleted = 4,
        All = Created | Updated | Deleted
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class EventAttribute : Attribute
    {

        public AMQPEvents events;
        public string routingKey;
        public string exchange;

        public EventAttribute(
            AMQPEvents events,
            string routingKey = "",
            string exchange = ""
            )
        {
            this.events = events;
            this.exchange = exchange;
            this.routingKey = routingKey;
        }
    }


}

