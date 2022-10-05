using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TokenManager
    {
        private readonly IConfiguration _config;
        public TokenManager(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]{
                     new Claim("UserId", user.Id.ToString()),
                     new Claim("Firstname", user.Firstname.ToString()),
                     new Claim("Lastname", user.Lastname.ToString()),
                     new Claim("Email", user.Email.ToString()),
                      new Claim(ClaimTypes.Name, user.Firstname),
                     new Claim(ClaimTypes.Role, "Artist")
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: signIn
                );

            var writeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return writeToken.ToString();
        }
        public void Edit(string userId,User user)
        {
           
        }
    }
}
