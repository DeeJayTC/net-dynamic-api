using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCDev.APIGenerator.Schema.Interfaces
{
    public interface ICacheService
    {
        public Task<bool> SaveData<T>(string name, T data);
        public Task<T> GetData<T>(string name);
        public void DeleteData(string name);
    }
}
