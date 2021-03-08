using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApiNetcore5.Services;
using WebAPiNetcore5.Controllers.V1.Request;

namespace WebAPiNetcore5.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost()]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userREgistrationRequest)
        {

            return Ok();
        }
    }
}
