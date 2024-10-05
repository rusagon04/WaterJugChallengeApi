using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterJugChallenge.Infrastructure
{
    public class ContextCache<Dto> : IContextCache<Dto>
    {
        private readonly IMemoryCache _MemoryCache;
        private string _CacheKey;
        private readonly MemoryCacheEntryOptions _CacheEntryOptions;

        public ContextCache(IMemoryCache memoryCache)
        {
            _MemoryCache = memoryCache;

            _CacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddHours(24),
                Priority = CacheItemPriority.Normal,
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };
        }

        public void SetCacheKey(string cacheKey)
        {
            _CacheKey = cacheKey;
        }

        public virtual List<Dto> Find()
        {
            return _MemoryCache.Get<List<Dto>>(_CacheKey) ?? new List<Dto>();
        }

        public virtual List<Dto> Find(Predicate<Dto> predicate)
        {
            return Find().FindAll(predicate);
        }

        public virtual void Set(List<Dto> dtos)
        {
            List<Dto> currentCache = Find();
            currentCache.AddRange(dtos);

            _MemoryCache.Set(_CacheKey, currentCache, _CacheEntryOptions);
        }

    }
}
