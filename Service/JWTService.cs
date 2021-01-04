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
        public static JwtSecurityToken token;

        public static JwtSecurityToken token;

        public JWTService(IConfiguration config, IUserServices userService)
        {
            _config = config;
            _userService = userService;
        }

        public string GenerateJSONWebToken(UserInformation userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.ID.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

                token = new JwtSecurityToken(_config["Jwt:Issuer"],
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
            if (foundUser != null)
            {
                if (login.Password == foundUser.Password && login.Email == foundUser.Email)
                {
                    user = new UserInformation {ID = foundUser.ID, Username = foundUser.Username, Email = foundUser.Email };

                }
                return user;
            }
            else
            {
                return user;
            }
        }
        public string GetID()
        {
            return token.Claims.First(claim => claim.Type == "sub").Value;

        }
        public string GetUsername()
        {
            return token.Claims.First(claim => claim.Type == "unique_name").Value;

        }


    }


}
