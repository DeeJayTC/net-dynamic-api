using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Interfaces;

namespace TCDev.APIGenerator.Schema.Interfaces
{

   public interface IAfterUpdate<T> where T : class
   {
      Task<T> AfterUpdate(T newItem, T oldItem);
   }
}
