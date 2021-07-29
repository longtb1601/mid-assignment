using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Services;

namespace MidAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _config; 
        public LoginController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }
   
        [HttpPost]    
        public IActionResult Login(UserDTO login)    
        {    
            IActionResult response = Unauthorized();    
            var user = _userService.GetUser(login);    
    
            if (user != null)    
            {    
                var tokenString = GenerateJSONWebToken(user);    
                response = Ok(new { token = tokenString });    
            }    
    
            return response;    
        }    

        private string GenerateJSONWebToken(User user)    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
              _config["Jwt:Issuer"],    
              null,    
              expires: DateTime.Now.AddMinutes(120),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    }
}