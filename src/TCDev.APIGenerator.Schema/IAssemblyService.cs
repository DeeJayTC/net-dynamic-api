using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema
{
    public interface IAssemblyService
    {
        public List<Assembly> Assemblies { get; set; }
        public List<Type> Types { get; set; }
    }
}
