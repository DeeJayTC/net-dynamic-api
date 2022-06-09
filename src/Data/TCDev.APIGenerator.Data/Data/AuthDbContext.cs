// TCDev.de 2022/04/24
// TCDev.APIGenerator.AuthDbContext.cs
// https://github.com/DeeJayTC/net-dynamic-api

using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TCDev.APIGenerator;
using TCDev.APIGenerator.Model;
using TCDev.APIGenerator.Model.Interfaces;
using TCDev.APIGenerator.Services;

namespace TCDev.APIGenerator.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        //public static IModel StaticModel { get; } = BuildStaticModel();
        private readonly AssemblyService assemblyService;
        private readonly IHttpContextAccessor context;
        private readonly IDatabaseProviderConfiguration dbConfigProvider;
        private readonly IConfiguration config;

        public AuthDbContext(
            DbContextOptions<AuthDbContext> options,
            IConfiguration config,
            AssemblyService assemblyService,
            IHttpContextAccessor accessor,
            IDatabaseProviderConfiguration databaseProviderConfiguration) : base(options)
        {
            this.assemblyService = assemblyService;
            this.context = accessor;
            this.dbConfigProvider = databaseProviderConfiguration;
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            dbConfigProvider.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
