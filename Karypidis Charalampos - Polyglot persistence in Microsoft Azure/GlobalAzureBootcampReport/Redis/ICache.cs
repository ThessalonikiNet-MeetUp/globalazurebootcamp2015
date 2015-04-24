using System;
using System.Threading.Tasks;

namespace GlobalAzureBootcampReport.Redis
{
    public interface ICache
    {
        string TopUsersStatsKey { get; }
        string AllUsersStatsKey { get; }

        /// <summary>
        /// Gets asynchronously the item with the supplied <paramref name="key"/> from the cache if exists.
        /// </summary>
        Task<T> GetItemAsync<T>(string key);

        /// <summary>
        /// Stores asynchronously the supplied <paramref name="data"/> object in the cache.
        /// </summary>
        Task SetItemAsync(string cacheKey, object data);
    }
}