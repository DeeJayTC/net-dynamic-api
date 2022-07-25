using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Events
{

    public class RabbitMQProducer : IMessageProducer, IDisposable
    {
        private AMQPOptions options;
        bool isInitialized = false;
        IModel? Channel { get; set; } = null;

        public RabbitMQProducer(ApiGeneratorConfig options)
        {
            this.options = options.AMQPOptions;
        }

        public void Dispose()
        {
            Channel.Dispose();
        }

        public void InitRabbitMQ()
        {
            var factory = new ConnectionFactory { HostName = options.Host };
            var connection = factory.CreateConnection();
            Channel = connection.CreateModel();

            Channel.ExchangeDeclare(
                options.Exchange, 
                options.ExchangeConfig.Type, 
                options.ExchangeConfig.Durable, 
                options.ExchangeConfig.AutoDelete);
            
            Channel.QueueDeclare(
                options.Queue, 
                options.QueueConfig.Durable, 
                options.QueueConfig.Exclusive, 
                options.QueueConfig.AutoDelete
                );
            
            Channel.QueueBind(
                options.Queue, 
                options.Exchange, 
                options.RoutingKey
                );
        }

        public void SendMessage<T>(T message)
        {
            // Initialize on first send
            if (!isInitialized || Channel == null ) InitRabbitMQ();

            if(Channel != null) { 
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                
                Channel.BasicPublish(
                    exchange: options.Exchange, 
                    routingKey: options.RoutingKey.ToString(),
                    body: body);
            }
        }
    }
}
