﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
                    ErrorMessage = new[] { "User alllready exists" }
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

            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor();


        }
    }
}