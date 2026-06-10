using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.Models;
using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IAuthService authService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            // Hide navbar for login page
            ViewData["HideNavbarAuth"] = true;

            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Hide navbar for login page
            ViewData["HideNavbarAuth"] = true;

            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.LoginAsync(new LoginDto
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            });

            if (!result.Success)
            {
                ModelState.AddModelError("", result.Message);
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var roles = await _userManager.GetRolesAsync(user);

            if (!string.IsNullOrEmpty(model.ReturnUrl) && model.ReturnUrl !="/" && Url.IsLocalUrl(model.ReturnUrl))
            {
                return LocalRedirect(model.ReturnUrl);
            }

            if (roles.Contains("Admin") || roles.Contains("InventoryManager"))
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login");
        }
    }
}
