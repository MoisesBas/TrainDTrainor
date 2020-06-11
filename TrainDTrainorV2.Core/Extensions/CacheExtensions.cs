using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Extensions
{
    public static class CacheExtensions
    {
        public static async Task<T> GetOrAddAsync<T>(this IMemoryCache cache, string key, Func<ICacheEntry, Task<T>> factory)
        {
            if (!cache.TryGetValue(key, out object obj))
            {
                var entry = cache.CreateEntry(key);
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                obj = (object)await factory(entry);
                entry.SetValue(obj);
                entry.Dispose();
                entry = (ICacheEntry)null;
            }

            return (T)obj;
        }
        public static T GetOrAdd<T>(this IMemoryCache cache, string key, Func<ICacheEntry, T> factory)
        {
            if (!cache.TryGetValue(key, out object obj))
            {
                var entry = cache.CreateEntry(key);
                entry.SlidingExpiration = TimeSpan.FromMinutes(60);
                obj = (object)factory(entry);
                entry.SetValue(obj);
                entry.Dispose();
                entry = (ICacheEntry)null;
            }

            return (T)obj;
        }
        public static bool IsExists(this IMemoryCache cache, string key)
        {
            return cache.TryGetValue(key, out object obj) ? true : false;
        }
    }
}
