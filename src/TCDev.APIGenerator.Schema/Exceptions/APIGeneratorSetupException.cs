using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema.Exceptions
{
    public class APIGeneratorSetupException : Exception
    {
        public APIGeneratorSetupException(string message, Exception innerException = null) : base(message, innerException)
        {
        }
    }
}
