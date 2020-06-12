using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly SignInManager<ToDoUser> signInManager;
        private readonly IConfiguration configuration;

        public UsersController(UserManager<ToDoUser> userManager,
            SignInManager<ToDoUser> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [Authorize]
        [HttpGet("self")]
        public async Task<IActionResult> Self()
        {
            if (User.Identity is ClaimsIdentity claimsIdentity)
            {
                var usernameClaim = claimsIdentity.FindFirst("UserId");
                var userId = usernameClaim.Value;

                var user = await userManager.FindByNameAsync(userId);
                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok(new
                {
                    UserId = user.Id,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.FavoriteFood,
                });

            }

            return Unauthorized();

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginData login)
        {
            var user = await userManager.FindByNameAsync(login.Username);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, login.Password);
                if (result)
                {
                    return Ok(new
                    {
                        UserId = user.Id,
                        Token = await CreateTokenAsync(user),
                    });
                }

                await userManager.AccessFailedAsync(user);
            }

            return Unauthorized();
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
                Token = await CreateTokenAsync(user),
            });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                user.EyeColor,
                user.FavoriteFood,
                user.Birthday,
            });
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, UpdateUserData data)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.EyeColor = data.EyeColor;
            user.FavoriteFood = data.FavoriteFood;
            user.Birthday = data.Birthday;

            await userManager.UpdateAsync(user);

            return Ok(new
            {
                UserId = user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                user.EyeColor,
                user.FavoriteFood,
                user.Birthday,
            });
        }

        private async Task<string> CreateTokenAsync(ToDoUser user)
        {
            var secret = configuration["JWT:Secret"];
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var signingKey = new SymmetricSecurityKey(secretBytes);

            var principal = await signInManager.CreateUserPrincipalAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;
            identity.AddClaims(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("UserId", user.Id),
                new Claim("FullName", $"{user.FirstName} {user.LastName}"),
            });

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(10),
                claims: identity.Claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
