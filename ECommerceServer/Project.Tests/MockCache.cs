using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Tests
{

    public class MockCache : ICacheService
    {
        public readonly IMemoryCache _memoryCache;

        public MockCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public void Set<T>(string key, T value, MemoryCacheEntryOptions options)
        {
            _memoryCache.Set(key, value, options);
        }
    }

    public interface ICacheService
    {
        bool TryGetValue<T>(string key, out T value);
        void Set<T>(string key, T value, MemoryCacheEntryOptions options);
    }
}