using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartSaver.Models;
using SmartSaver.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IJWTService _JWTService;
   
        public LoginController(IJWTService jwtService)
        {
            _JWTService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserInformation login)
        {
            IActionResult response = Unauthorized();
            var user = _JWTService.AuthenticateUserAsync(login);

            if (user.Result != null)
            {
                var tokenString = _JWTService.GenerateJSONWebToken(user.Result);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

    }
}
