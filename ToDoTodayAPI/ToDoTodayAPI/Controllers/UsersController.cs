using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ToDoTodayAPI.Models;
using ToDoTodayAPI.Models.Identity;

namespace ToDoTodayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ToDoUser> userManager;
        
        public IConfiguration Configuration { get; }

        public UsersController(UserManager<ToDoUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            Configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterData register)
        {
            var user = new ToDoUser
            {
                Email = register.Email,
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Registration Failed",
                    errors = result.Errors,

                });
            }
            return Ok(new
            {
                UserId = user.Id,
                Token = CreateToken(user),
            });
        }

        private string CreateToken(ToDoUser user)
        {
            var secret = configuration["JWT:Secret"];
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);

            var tokenClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserId", user.Id),
                new Claim("FullName", $"{user.FirstName}{user.LastName}"),
            };

            var token = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
