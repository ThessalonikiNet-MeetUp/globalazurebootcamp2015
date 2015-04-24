using System;
using System.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace GlobalAzureBootcampReport.Redis
{
    /// <summary>
    /// Implementation of <see cref="ICache"/>
    /// </summary>
    internal class Cache : ICache
    {

        private static readonly string RedisConnectionString = ConfigurationManager.AppSettings["RedisConnectionString"];
        private static readonly Lazy<ConnectionMultiplexer> Connection = new Lazy<ConnectionMultiplexer>(() =>
            ConnectionMultiplexer.Connect(RedisConnectionString));

        private static ConnectionMultiplexer RedisConnection
        {
            get
            {
                return Connection.Value;
            }
        }

        public string TopUsersStatsKey
        {
            get { return "TopUsersStatsKey"; }
        }

        public string AllUsersStatsKey
        {
            get { return "AllUsersStatsKey"; }
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var db = RedisConnection.GetDatabase();
            var cacheValue = await db.StringGetAsync(key).ConfigureAwait(false);
            if (String.IsNullOrEmpty(cacheValue)) return default(T);

            var data = JsonConvert.DeserializeObject<T>(cacheValue);

            return data;
        }

        public async Task SetItemAsync(string key, object data)
        {
            var cacheValue = JsonConvert.SerializeObject(data);

            // update value in redis
            var db = RedisConnection.GetDatabase();
            await db.StringSetAsync(key, cacheValue).ConfigureAwait(false);
        }
    }
}