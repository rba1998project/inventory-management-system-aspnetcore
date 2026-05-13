using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.Models;
using Microsoft.AspNetCore.Identity;

namespace IMS.BLL.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return Task.FromResult(_userManager.Users.ToList());
        }

        public Task<List<string>> GetAllRolesAsync()
        {
            return Task.FromResult(_roleManager.Roles.Select(r => r.Name).ToList());
        }

        public async Task<Dictionary<string, string>> GetUserRolesMapAsync(List<ApplicationUser> users)
        {
            var result = new Dictionary<string, string>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                result[user.Id] = roles.FirstOrDefault() ?? "";
            }

            return result;
        }

        public async Task<IdentityResult> CreateUserAsync(CreateUserDto dto)
        {
            var user = new ApplicationUser
            {
                Email = dto.Email,
                UserName = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return result;

            if (!await _roleManager.RoleExistsAsync(dto.Role))
                await _roleManager.CreateAsync(new IdentityRole(dto.Role));

            await _userManager.AddToRoleAsync(user, dto.Role);

            return result;
        }

        public async Task<IdentityResult> UpdateUserRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.DeleteAsync(user);
        }
    }
}
