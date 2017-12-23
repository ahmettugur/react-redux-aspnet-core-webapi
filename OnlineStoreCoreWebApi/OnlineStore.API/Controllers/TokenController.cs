using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using OnlineStore.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineStore.Business.Contracts;
using OnlineStore.Entity.Concrete;
using Newtonsoft.Json;

namespace OnlineStore.API.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Token")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userServive;
        public TokenController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userServive = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public IActionResult Post([FromBody]LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                //This method returns user id from username and password.
                var user = GetUserIdFromCredentials(loginViewModel);
                if (user == null)
                {
                    return NotFound("Invaliid Username and password");
                }

                var jsonUser = JsonConvert.SerializeObject(user);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,""),
                    new Claim(ClaimTypes.Name,"tokenAuthentication"),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.UserData,jsonUser),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Issuer"],
                    audience: _configuration["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(10),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"])),
                            SecurityAlgorithms.HmacSha256)
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }

        private User GetUserIdFromCredentials(LoginViewModel loginViewModel)
        {
            var user = _userServive.Get(_ => _.Email == loginViewModel.Email && _.Password == loginViewModel.Password);
            //var userId = -1;
            //if (loginViewModel.Username == "demo" && loginViewModel.Password == "demo")
            //{
            //    userId = 5;
            //}

            return user;
        }
    }
}