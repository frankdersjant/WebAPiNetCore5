using System.Collections.Generic;

namespace WebApiNetcore5.Model
{
    public class AuthenticationResult
    {

        public string Token { get; set; }
        public bool IsSucces { get; set; }
        public IEnumerable<string> ErrorMessage { get; set; }
    }
}
