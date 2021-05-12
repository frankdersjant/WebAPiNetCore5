using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebAPiNetcore5.Services;

namespace WebAPiNetcore5.Cache
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int TTL;

        public CacheAttribute(int tTL)
        {
            TTL = tTL;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            //before
            var cachesetting = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();

            if(!cachesetting.Enabled)
            {
                await next();
                return;
            }

            var responseCacheservice = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();


            await next();
            //after
        }
    }
}
