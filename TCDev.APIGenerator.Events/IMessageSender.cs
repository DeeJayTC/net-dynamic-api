using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Events
{
    public interface IMessageSender
    {
        public void Send();
    }


    public class RabbitMQSender : IMessageSender
    {
        
        
        public void Send()
        {

        }
    }
}
