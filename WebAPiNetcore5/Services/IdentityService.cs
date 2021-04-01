using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiNetcore5.Model;
using WebAPiNetcore5.Options;

namespace WebAPiNetcore5.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JWTSettings _jwtSettings;
        public IdentityService(UserManager<IdentityUser> userManager, JWTSettings jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResult> RegisterAsync(string Email, string Password)
        {
            var foundUser = await _userManager.FindByEmailAsync(Email);

            if (foundUser is not null)
            {
                return new AuthenticationResult
                {
                    ErrorMessage = new[] { "User allready exists" }
                };
            }

            var newUser = new IdentityUser
            {
                Email = Email,
                UserName = Email
            };

            var createdUser = await _userManager.CreateAsync(newUser, Password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    ErrorMessage = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthenticationResultForUser(newUser);
        }

        private AuthenticationResult GenerateAuthenticationResultForUser(IdentityUser newUser)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {


                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(3.00),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                IsSucces = true,
                Token = TokenHandler.WriteToken(token)
            };
        }

        public async Task<AuthenticationResult> LoginAsync(string Email, string Password) 
        {
            var foundUser = await _userManager.FindByEmailAsync(Email);

            if (foundUser is not null)
            {
                return new AuthenticationResult
                {
                    ErrorMessage = new[] { "User allready exists" }
                };
            }

            var UserHasValidPasword = await _userManager.CheckPasswordAsync(foundUser, Password);

            if (!UserHasValidPasword)
            { 
                return new AuthenticationResult
                {
                    ErrorMessage = new[] { "User password incorrect" }
                };
            }

            return GenerateAuthenticationResultForUser(foundUser);
        }
    }
}
