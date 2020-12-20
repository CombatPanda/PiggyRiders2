using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartSaver.Contexts;
using SmartSaver.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartSaver.Service
{
    public class JWTService : IJWTService
    {
        private IConfiguration _config;
        private readonly IUserServices _userService;

        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public JWTService(IUserServices userService)
        {
            _userService = userService;
        }

        public string GenerateJSONWebToken(UserInformation userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserInformation> AuthenticateUserAsync(UserInformation login)
        {
            UserInformation user = null;

            UserInformation foundUser = await _userService.CheckUser(login);
  
            if (login.Password == foundUser.Password && login.Email == foundUser.Email && login.Username == foundUser.Username)
            {
                user = new UserInformation { Username = foundUser.Username, Email = foundUser.Email };
            }
            return user;
        }

    }
}
