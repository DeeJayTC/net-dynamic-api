using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Events;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.Extension
{
    public static partial class ServiceExtension
    {



        public static ApiGeneratorServiceBuilder AddRabbitMQ(
            this ApiGeneratorServiceBuilder builder)
        {
            if(string.IsNullOrEmpty(builder.ApiGeneratorConfig.AMQPOptions.Host))
            {
                throw new ArgumentException("Provide a host connection string in configuration before initiating RabbitMQ");
            }
            try
            {
                builder.Services.AddSingleton(typeof(IMessageProducer), typeof(RabbitMQProducer));
                
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Could not add the RabbitMQ Connection, make sure your connection string is correct.");
            }

            return builder;
        }
    }
}