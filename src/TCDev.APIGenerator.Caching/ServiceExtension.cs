using Microsoft.Extensions.DependencyInjection;
using System;
using TCDev.APIGenerator.Redis;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Extension
{
    public static partial class ServiceExtension
    {


        public static ApiGeneratorServiceBuilder AddRedisCache(
            this ApiGeneratorServiceBuilder builder)
        {
            if(builder.ApiGeneratorConfig.DatabaseOptions.Connection == null)
            {
                throw new ArgumentException("Provide a connection string in configuration before initiating Database");
            }
            try
            {
                builder.Services.AddSingleton(typeof(ICacheService), typeof(RedisService));
            }
            catch(Exception ex)
            {
                throw new ArgumentException("Could not add the Database connection, make sure your connection string is correct.");
            }

            return builder;
        }
    }
}