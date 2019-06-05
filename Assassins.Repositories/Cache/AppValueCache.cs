using Microsoft.Extensions.Caching.Memory;
using System;

namespace Assassins.DataAccess.Cache
{
    public static class AppValueCache
    {
        private static MemoryCache memCache = new MemoryCache(new MemoryCacheOptions());
        private static readonly int CacheLifetimeMins = 30;

        internal static bool Contains(string key)
        {
            return memCache.Get(key) != null;
        }
        internal static object Get(string key)
        {
            return memCache.Get(key);
        }
        internal static void Set(string key, object obj)
        {
            memCache.Set(key, obj, DateTime.UtcNow.AddMinutes(CacheLifetimeMins));
        }

        internal static void Set(string key, object obj, int lifeTimeInMins)
        {
            memCache.Set(key, obj, DateTime.UtcNow.AddMinutes(lifeTimeInMins));
        }
        internal static void Clear(string key)
        {
            memCache.Remove(key);
        }

    }
}
