using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Model.Interfaces
{
    public interface IDatabaseProviderConfiguration
    {
        public abstract void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}
