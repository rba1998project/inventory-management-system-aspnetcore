using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _service;

        public UserManagementController(IUserManagementService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _service.GetAllUsersAsync();
            ViewBag.Roles = await _service.GetAllRolesAsync();
            ViewBag.UserRoles = await _service.GetUserRolesMapAsync(users);

            return View(users);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await _service.GetAllRolesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existingUser = await _service.GetUserByEmailAsync(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "User with this email already exists.");
                ViewBag.Roles = await _service.GetAllRolesAsync();
                return View(model);
            }

            var dto = new UserCreateDto
            {
                Email = model.Email,
                Password = model.Password,
                Role = model.Role
            };

            var referer = User.Identity.Name;

            var result = await _service. UserCreateAsync(dto, referer);

            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                    ModelState.AddModelError("", e.Description);

                ViewBag.Roles = await _service.GetAllRolesAsync();
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(string userId, string role)
        {

            var referer = User.Identity.Name;
            await _service.UpdateUserRoleAsync(userId, role, referer);

            TempData["SuccessMessage"] = "Role updated successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            var referer = User.Identity.Name;
            await _service.DeleteUserAsync(userId, referer);
            return RedirectToAction("Index");
        }
    }
}