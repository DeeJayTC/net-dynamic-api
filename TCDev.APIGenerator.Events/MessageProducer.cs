using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Events
{

    public class RabbitMQProducer : IMessageProducer
    {
        private AMQPOptions options;
        bool isInitialized = false;

        public RabbitMQProducer(ApiGeneratorConfig options)
        {
            this.options = options.AMQPOptions;
        }
        
        public void InitRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
        }

        public void SendMessage<T>(T message)
        {
            // Initialize on first send
            if (!isInitialized) InitRabbitMQ();
            
            throw new NotImplementedException();
        }
    }
}
