using System;
using System.Threading.Tasks;

namespace WebAPiNetcore5.Services
{
    //TODO : move to service layer
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cachekey, object responseObject, TimeSpan TTL);
        Task<string> GetCachedResponseAsync(string cachekey);
    }
}
