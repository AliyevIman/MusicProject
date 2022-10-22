using DataAccess.Concrete.EntityFrameWork;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MusicProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimSetUpController : ControllerBase
    {
        private readonly MusicDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        protected readonly ILogger<ClaimSetUpController> _logger;

        public ClaimSetUpController(
            MusicDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            ILogger<ClaimSetUpController> logger)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAllClaims(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claims = await _userManager.GetClaimsAsync(user);

            return Ok(claims);
        }

        // Add Claim to user
        [HttpPost]
        [Route("AddClaimToUser")]
        public async Task<IActionResult> AddClaimToUser(string email, string claimName, string value)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var userClaim = new Claim(claimName, value);

            if (user != null)
            {
                var result = await _userManager.AddClaimAsync(user, userClaim);

                if (result.Succeeded)
                {
                    _logger.LogInformation(1, $"the claim {claimName} add to the  User {user.Email}");
                    return Ok(new { result = $"the claim {claimName} add to the  User {user.Email}" });
                }
                else
                {
                    _logger.LogInformation(1, $"Error: Unable to add the claim {claimName} to the  User {user.Email}");
                    return BadRequest(new { error = $"Error: Unable to add the claim {claimName} to the  User {user.Email}" });
                }
            }

            // User doesn't exist
            return BadRequest(new { error = "Unable to find user" });
        }
    }
}
