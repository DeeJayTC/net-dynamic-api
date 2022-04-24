using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Data;

namespace TCDev.APIGenerator.Data
{
    public class ApplicationData
    {
        public GenericDbContext GenericData {get;set;}
        public AuthDbContext AuthData { get; set; }
        
        public HttpContext Context { get; set; }
        
        public ApplicationData(GenericDbContext genericData, AuthDbContext authData, HttpContext context)
        {
            GenericData = genericData;
            AuthData = authData;
            Context = context;
        }
    }
}
