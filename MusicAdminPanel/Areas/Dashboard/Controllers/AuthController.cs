using AutoMapper;
using Business.Concrete;
using Entites.Concrete;
using Entites.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MusicAdminPanel.Areas.Dashboard.ViewModel;

namespace MusicAdminPanel.Areas.Dashboard.Controllers
{
    [Area("dashboard")]

    public class AuthController : Controller

    {

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.roleManager = roleManager;
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user == null) return NotFound();
            var roles = await _userManager.GetRolesAsync(user);

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (!result.Succeeded&&roles==null)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Home");
            //var findUser = await _userManager.FindByEmailAsync(loginVM.Email);
            //if (findUser == null) return View();

            //var checkPassword = await _userManager.CheckPasswordAsync(findUser, loginVM.Password);
            //var roles = await _userManager.GetRolesAsync(findUser);

            //if (roles == null && !checkPassword)
            //{
            //    return BadRequest();

            //}
            //return RedirectToAction("Index", "Home");



        }

    }
}
