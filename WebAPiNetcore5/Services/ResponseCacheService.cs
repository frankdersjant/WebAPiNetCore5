using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPiNetcore5.Services
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cachekey, object responseObject, TimeSpan TTL)
        {
            if (responseObject is null)
            {
                return;
            }

            var serilizedResponse = JsonConvert.SerializeObject(responseObject);

            await distributedCache.SetStringAsync(cachekey, serilizedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TTL
            });
        }

        public async Task<string> GetCachedResponseAsync(string cachekey)
        {
            var cacheResponse = await distributedCache.GetStringAsync(cachekey);

            return string.IsNullOrEmpty(cacheResponse) ? null : cacheResponse;
        }
    }
}
