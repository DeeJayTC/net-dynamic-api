using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Services
{
   public class AssemblyService
   {
      public List<Assembly> Assemblies { get; set; } = new List<Assembly>();
      public List<Type> Types { get; set; } = new List<Type>();
   }
}
