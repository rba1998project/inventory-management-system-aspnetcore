using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IMS.BLL.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserManagementService> _logger;

        public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<UserManagementService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();
        }

        public async Task<List<string>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.Select(r => r.Name).OrderBy(name => name).ToListAsync();
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
        
        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult>  UserCreateAsync(UserCreateDto dto, string referer)
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

            _logger.LogInformation(
                        "User {UserEmail} created with role {UserRole} by {Referer}",
                        dto.Email,
                        dto.Role,
                        referer);

            return result;
        }

        public async Task<IdentityResult> UpdateUserRoleAsync(string userId, string role, string referer)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, roles);

            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));

            var result = await _userManager.AddToRoleAsync(user, role);

            if (result.Succeeded)
            {
                _logger.LogInformation(
                            "User {UserEmail} role updated to {UserRole} by {Referer}",
                            user.Email,
                            role,
                            referer);
            }

            return result;
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId, string referer)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation(
                            "User {UserEmail} deleted by {Referer}",
                            user.Email,
                            referer);
            }

            return result;
        }
    }
}
