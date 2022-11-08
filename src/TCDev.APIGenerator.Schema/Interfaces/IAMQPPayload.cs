using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.APIGenerator.Events;
    
namespace TCDev.APIGenerator.Schema.Interfaces
{
    
    public class AMQPPayload<T> where T: class
    {
        public AMQPEvents eventNum { get;set; }
        public string eventName { get; set; }
        public T data { get; set; }
        public T? oldData { get; set; }
    }
}
