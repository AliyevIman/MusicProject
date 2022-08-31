using AutoMapper;
using Business.Concrete;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly TokenManager _tokenManager;
        public AccountController(UserManager<User> userManager, IMapper mapper, IConfiguration config, TokenManager tokenManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
            _tokenManager = tokenManager;
        }

     
     

        // POST api/<AccountController>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return Ok(new { status = 201, message = "user created" });  
        }

        // POST api/<AccountController>
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO userDTO)
        {
            var findUser = await _userManager.FindByEmailAsync(userDTO.Email);
            var checkPassword = await _userManager.CheckPasswordAsync(findUser, userDTO.Password);
            if (findUser != null && checkPassword)
            {

                var myToken = _tokenManager.GenerateToken(findUser);

                return Ok(new { email = findUser.Email, token = myToken });
            }

            return Unauthorized();

        }
       
    }
}

