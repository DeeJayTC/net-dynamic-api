using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;
using TCDev.APIGenerator.Schema.Interfaces;

namespace TCDev.APIGenerator.Redis
{
    public class RedisService : ICacheService
    {
        private RedisConnection redisConnection;
        private readonly IConfiguration config;
        private readonly ApiGeneratorConfig apiGenConfig;
        
        public RedisService(IConfiguration config, ApiGeneratorConfig apiGenConfig)
        {
            this.config = config;
            this.apiGenConfig = apiGenConfig;
        }

        // Init redis connection on first use
        private async Task Init()
        {
            this.redisConnection = await RedisConnection.InitializeAsync(connectionString: apiGenConfig.CacheOptions.Connection);
        }

        public async Task<bool> SaveData<T>(string name, T data)
        {
            if (redisConnection == null) await Init();
            var result = await redisConnection.BasicRetryAsync(async (db) => await db.StringSetAsync(name, JsonConvert.SerializeObject(data)));
            return result;
        }

        public async Task<T> GetData<T>(string name)
        {
            if (redisConnection == null) await Init();
            var result = await redisConnection.BasicRetryAsync(async (db) => await db.StringGetAsync(name));
            if (result.HasValue)
                return JsonConvert.DeserializeObject<T>(result);
            return default;
        }

        public async void DeleteData(string name)
        {
            if (redisConnection == null) await Init();
            var result = await redisConnection.BasicRetryAsync(async (db) => await db.KeyDeleteAsync(name, CommandFlags.FireAndForget));
        }

    }
}
