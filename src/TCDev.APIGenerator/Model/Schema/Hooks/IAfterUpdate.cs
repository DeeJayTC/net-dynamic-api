using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Interfaces;
using TCDev.ApiGenerator.Data;
using TCDev.APIGenerator.Data;

namespace TCDev.ApiGenerator.Schema.Interfaces
{

   public interface IAfterUpdate<T> where T : class
   {
        Task<T> AfterUpdate(T newItem, T oldItem, ApplicationDataService data);
    }
}
