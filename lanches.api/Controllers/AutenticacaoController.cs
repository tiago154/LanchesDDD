﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lanches.api.Controllers
{
    [Route("autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post(LoginModel login)
        {
            IActionResult response = Unauthorized();

            var user = new UserModel { Birthdate = DateTime.Now, Email = "teste@teste.com", Name = "Teste" };
            var tokenString = BuildToken(user);
            response = Ok(new { token = tokenString });

            return response;
        }
        private string BuildToken(UserModel user)
        {
            var identity = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("teste", "testeClaim")
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("231qw32e15sa64d5sa6456wqe132wq1e32qw132qew132"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken("https://localhost:44388",
                "https://localhost:44388",
                claims: identity,
                expires: DateTime.Now.AddHours(30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class UserModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Birthdate { get; set; }
        }
    }
}
