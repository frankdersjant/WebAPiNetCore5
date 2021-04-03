using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApiNetcore5.Services;
using WebAPiNetcore5.Controllers.V1.Request;
using WebAPiNetcore5.Controllers.V1.Response;
using WebAPiNetcore5.Services;

namespace WebAPiNetcore5.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("api/v1/Identity")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userRegistrationRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailureResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))

                });
            }

            var authResponse = await _identityService.RegisterAsync(userRegistrationRequest.Email, userRegistrationRequest.Password);

            if (!authResponse.IsSucces)
            {
                return BadRequest(new AuthFailureResponse
                {
                    Errors = authResponse.ErrorMessage
                });
            }

            return Ok(new AuthSuccesResponse
            {
                Token = authResponse.Token
            });
        }

        [HttpPost("api/v1/Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            var authResponse = await _identityService.LoginAsync(userLoginRequest.Email, userLoginRequest.Password);

            if (!authResponse.IsSucces)
            {
                return BadRequest(new AuthFailureResponse
                {
                    Errors = authResponse.ErrorMessage
                });
            }

            return Ok(new AuthSuccesResponse
            {
                Token = authResponse.Token
            });
        }
    }
}
