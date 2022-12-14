using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Entites.Concrete;
using Entites.DTO;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
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
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly TokenManager _tokenManager;
        protected readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<User> userManager, IMapper mapper, IConfiguration config, TokenManager tokenManager, RoleManager<IdentityRole> roleManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
            _tokenManager = tokenManager;
            this.roleManager = roleManager;
            _logger = logger;
        }


        // POST api/<AccountController>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);


            await _userManager.AddToRoleAsync(user, "User");

            var myToken = _tokenManager.GenerateToken(user);
            if (!result.Succeeded)
            {
                return BadRequest(new { status = 401 });
            }

            return Ok(new { status = 201, token = myToken });
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO userDTO)
        {
            var findUser = await _userManager.FindByEmailAsync(userDTO.Email);
            var checkPassword = await _userManager.CheckPasswordAsync(findUser, userDTO.Password);
            if (findUser != null && checkPassword)
            {
                var myToken = _tokenManager.GenerateToken(findUser);


                return Ok(new { status = 200, email = findUser.Email, token = myToken });
            }

            return BadRequest();

        }

        [HttpPut("Update/{userId}")]
        public async Task<IActionResult> EditUser([FromBody] EditMusicianDTO userDTO, string userId)
        {
            var findUser = await _userManager.FindByIdAsync(userId);
            var user = _mapper.Map<User>(userDTO);
            if (findUser != null)
            {
                user.UserName = userDTO.Email;

                var edit = await _userManager.UpdateAsync(user);
                if (edit.Succeeded)
                {
                    return Ok(edit);

                }
                else
                {
                    return BadRequest(edit.Errors);
                }
            }
            return BadRequest();

        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 1
                var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));

                if (roleResult.Succeeded)
                {
                    _logger.LogInformation(1, "Roles Added");
                    return Ok(new { result = $"Role {roleName} added successfully" });
                }
                else
                {
                    _logger.LogInformation(2, "Error");
                    return BadRequest(new { error = $"Issue adding the new {roleName} role" });
                }
            }

            return BadRequest(new { error = "Role already exist" });
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                var myToken = _tokenManager.GenerateToken(user);

                if (result.Succeeded)
                {
                    _logger.LogInformation(1, $"User {user.Email} added to the {roleName} role");
                    return Ok(new { email = user.Email, roleName = roleName, token = myToken });
                }
                else
                {
                    _logger.LogInformation(1, $"Error: Unable to add user {user.Email} to the {roleName} role");
                    return BadRequest(new { error = $"Error: Unable to add user {user.Email} to the {roleName} role" });
                }
            }

            // User doesn't exist
            return BadRequest(new { error = "Unable to find user" });
        }
        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            // Resolve the user via their email
            if (email == null)
            {
                return NotFound(new { error = $"Error: Can not found  {email} about  to the  role" });

            }
            var user = await _userManager.FindByEmailAsync(email);

            // Get the roles for the user
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }

        // Remove User to role
        [HttpPost]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    _logger.LogInformation(1, $"User {user.Email} removed from the {roleName} role");
                    return Ok(new { result = $"User {user.Email} removed from the {roleName} role" });
                }
                else
                {
                    _logger.LogInformation(1, $"Error: Unable to removed user {user.Email} from the {roleName} role");
                    return BadRequest(new { error = $"Error: Unable to removed user {user.Email} from the {roleName} role" });
                }
            }

            // User doesn't exist
            return BadRequest(new { error = "Unable to find user" });
        }



    }
}

