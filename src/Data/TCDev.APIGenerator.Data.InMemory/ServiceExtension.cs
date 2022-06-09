using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using TCDev.APIGenerator.Data;
using TCDev.APIGenerator.Model.Interfaces;

namespace TCDev.APIGenerator.Extension
{
    public static partial class ServiceExtension
    {

        public static ApiGeneratorServiceBuilder AddDataContextInMemory(
            this ApiGeneratorServiceBuilder builder)
        {

            builder.Services.AddDbContext<GenericDbContext>(options =>
            {
                options.UseInMemoryDatabase("APIGenerator");
            });

            builder.Services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseInMemoryDatabase("APIGeneratorAuth");
            });

            return builder;
        }
    }
}