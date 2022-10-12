using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Core.Security.Hasing;
using Core.Security.TokenHandler;
using Entites.Concrete;
using Entites.DTO;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly TokenManager _tokenManager;
        private readonly HashingHandler _hashingHandler;
        private readonly IRoleManager _role;
        private readonly IAuthManager _authManager;
        private readonly TokenGenerator _tokenGenerator;

        public AccountController(IMapper mapper, IConfiguration config, TokenManager tokenManager, IRoleManager role, IAuthManager authManager, HashingHandler hashingHandler, TokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _config = config;
            _tokenManager = tokenManager;
            _role = role;
            _authManager = authManager;
            _hashingHandler = hashingHandler;
            _tokenGenerator = tokenGenerator;
        }


        // POST api/<AccountController>
        [HttpGet("getall")]
        public ActionResult <string> GetMe()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Your secret key value"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("user", "Artist"));

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken("your-issuer.com",
                                                "your-audience.com",
                                                permClaims,
                                                expires: DateTime.Now.AddDays(1),
                                                signingCredentials: credentials);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(jwtToken);
            string user = jwt.Claims.First(c => c.Type == "user").Value;
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO model)
        {
            //var user = _mapper.Map<User>(userDTO);
            //user.Email = userDTO.Email;
            //var result = await _userManager.CreateAsync(user, userDTO.Password);
            //if (!result.Succeeded)
            //{
            //    return BadRequest();
            //}
            //return Ok(new { status = 201, message = "user created" });  
            var user = _authManager.GetUserByEmail(model.Email);

            if (user != null)
            {
                return Ok(new { status = 201, message = "Email is exist." });
            }
            _authManager.Register(model);

            return Ok(new { status = 200, message = "Okey" });
        }

        // POST api/<AccountController>
        [HttpPost("login")]
        public async Task<object> LoginUser( LoginUserDTO model)
        {

            //var findUser = await _userManager.FindByEmailAsync(userDTO.Email);

            //var checkPassword = await _userManager.CheckPasswordAsync(findUser, userDTO.Password);

            //if (findUser != null && checkPassword)
            //{
            //    var role = _role.GetRole(user.Id);
            //    var resultUser = new UserDTO(user.Id, user.FullName, user.Email);
            //   resultUser.Token = _tokenManager.GenerateToken(findUser,role.Name);
            //    return Ok(new { email = findUser.Email, token = resultUser });
            //}

            var user = _authManager.Login(model.Email);
            if (user == null) return Ok(new { status = 404, message = "Bele bir istifadeci tapilmadi." });

            if (user.Email == model.Email && user.Password == _hashingHandler.PasswordHash(model.Password))
            {

                var role = _role.GetRole(user.Id);
                var resultUser = new UserDTO(user.Id, user.FullName, user.Email);
                resultUser.Token = _tokenGenerator.Token(user, role.Name);

                return Ok(new { status = 200, message = resultUser });
            }

            return Ok(new { status = 404, message = "Email ve ya sifre sehfdi." });

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("allusers")]
        public List<User> GetUsers()
        {
            return _authManager.GetUsers();
        }

        [HttpGet("getuserbyrole/{userId}")]
        public async Task<Role> GetUserByRole(int userId)
        {
            return _role.GetRole(userId);
        }
        [Authorize]
        [HttpGet("getbyemail")]
        public async Task<object> GetByEmail()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var email = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "email").Value;

            var user = _authManager.GetUserByEmail(email);
            var result = new UserDTO(user.Id, user.FullName, user.Email);
            return Ok(result);
        }
        //private string CreateToken (User user)
        //{
        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.FullName),
        //        new Claim(ClaimTypes.Role, "Artist"),
        //    };

        //    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
        //        _config.GetSection("Jwt:key").Value));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //    var token = new JwtSecurityToken(
        //        claims: claims,
        //        expires: DateTime.Now.AddDays(1),
        //        signingCredentials: creds);

        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //    return jwt;

        //}
        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new HMACSHA512(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        return computedHash.SequenceEqual(passwordHash);
        //    }
        //}

    }
}

