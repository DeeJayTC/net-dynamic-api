using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Events
{

    [AttributeUsage(AttributeTargets.Class)]
    public class CachableAttribute : Attribute
    {

        public string cacheKey;
        public int defaultLifeTime;

        public CachableAttribute(
            string cacheKey = "",
            int defaultLifeTime = 60
            )
        {
            this.cacheKey = cacheKey;
            this.defaultLifeTime = defaultLifeTime;
        }
    }
}