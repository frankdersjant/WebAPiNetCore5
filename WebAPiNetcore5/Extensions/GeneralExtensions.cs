using Microsoft.AspNetCore.Http;
using System.Linq;

namespace WebAPiNetcore5.Extensions
{
    public static class GeneralExtensions
    {
        //Will return userid from Token
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User is null)
            {
                return string.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "id").Value; 
        }
    }
}
