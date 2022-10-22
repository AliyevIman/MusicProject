using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Core.Abstract;
using System.Security.Cryptography.Pkcs;

namespace Business.Concrete
{
    public class TokenManager
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        //private readonly IunitOfWork unitOfWork;
        private readonly IConfiguration _config;
        //private readonly TokenValidationParameters _tokenValidationParameters;
        //private readonly IRefreshTokensDal refreshToken;


        public TokenManager(IConfiguration config, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            //this.refreshToken = refreshToken;
            //_tokenValidationParameters = tokenValidationParameters;
            //this.unitOfWork = unitOfWork;
        }

        public async Task<AuthResult> GenerateToken(User user)
        {
            using MusicDbContext _context = new();
            var jwtTokenHAndler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var claims = await GetAllValidClaims(user);

            //var claims = new[]{
            //         new Claim("Id", user.Id.ToString()),
            //         new Claim("Firstname", user.Firstname.ToString()),
            //         new Claim("Lastname", user.Lastname.ToString()),
            //         new Claim("Email", user.Email.ToString()),
            // };

            //var claims = GetAllClaims
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var token = new JwtSecurityToken(
            //    _config["Jwt:Issuer"],
            //    _config["Jwt:Audience"],
            //    claims,
            //    expires: DateTime.UtcNow.AddDays(10),
            //    signingCredentials: signIn
            //    );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(30),
                SigningCredentials = signIn
            };

            //var writeToken = new JwtSecurityTokenHandler().WriteToken(token);
            var Mytoken = jwtTokenHAndler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHAndler.WriteToken(Mytoken);
            // refresh toekn
            var refreshToken = new RefreshToken
            {
                AddedTime = DateTime.UtcNow,
                Token = $"{RandomStringGenerator(25)}_{Guid.NewGuid()}", // Create a method genreate rasdnom string
                UserId = user.Id,
                IsRoveked = false,
                IsUsed = false,
                Status = 1,
                jwtId = Mytoken.Id,
                ExpiredDate = DateTime.UtcNow.AddMonths(6),
            };

            //await unitOfWork.ComplateAsync();
            //return writeToken.ToString();
            return new AuthResult()
            {
                Token = jwtToken,
                Success = true,
                RefreshToken = refreshToken.Token
            };
        }
        private string RandomStringGenerator(int lenght)
        {
            var rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPRSTUWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, lenght).
                Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        private async Task<List<Claim>> GetAllValidClaims(IdentityUser user)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
            };

            var userClaims = await _userManager.GetClaimsAsync((User)user);
            var userRoles = await _userManager.GetRolesAsync((User)user);
            claims.AddRange(userClaims);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }


    }
}
