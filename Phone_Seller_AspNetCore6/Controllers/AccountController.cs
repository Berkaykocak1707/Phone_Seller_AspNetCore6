using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Phone_Seller_AspNetCore6.Models;

namespace Phone_Seller_AspNetCore6.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        public AccountController(UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl)
        {
            if (ReturnUrl == null)
            {
                ReturnUrl = "/";
            }
            var errorMessage = TempData["ErrorMessage"] as string;
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = await _userManager.FindByNameAsync(model.Username);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if((await _signInManager.PasswordSignInAsync(user, model.Password,false,false)).Succeeded)
                    {
                        return Redirect(model.ReturnUrl ?? "/demo");
                    }
                }
                TempData["ErrorMessage"] = "Username or password not found.";
            }
            return View();
        }
        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var user = new CustomUser
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return RedirectToAction(
                        "Login", 
                        new {ReturnUrl = "/"} 
                    );
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
