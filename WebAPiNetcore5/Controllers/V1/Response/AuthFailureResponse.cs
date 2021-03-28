using System.Collections.Generic;

namespace WebAPiNetcore5.Controllers.V1.Response
{
    public class AuthFailureResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
