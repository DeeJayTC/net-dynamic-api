using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDev.ApiGenerator.Interfaces;

namespace TCDev.APIGenerator.Schema.Interfaces
{
   public interface IEventDelegates<T> where T : class
   {

      Task<T> BeforeUpdate(T item);
      Task<T> AfterUpdate(T item);

   }
}
