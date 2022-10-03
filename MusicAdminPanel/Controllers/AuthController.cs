using AutoMapper;
using Business.Concrete;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MusicAdminPanel.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

  

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDTO loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return View();

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (!result.Succeeded)
            {
                return View();
            }

            return RedirectToAction("Index", "Dashboard");
        }

    }
}
