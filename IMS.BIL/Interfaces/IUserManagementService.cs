using IMS.BLL.DTOs;
using IMS.Models;
using Microsoft.AspNetCore.Identity;

namespace IMS.BLL.Interfaces
{
    public interface IUserManagementService
    {
        Task<List<ApplicationUser>> GetAllUsersAsync();

        Task<List<string>> GetAllRolesAsync();

        Task<Dictionary<string, string>> GetUserRolesMapAsync(List<ApplicationUser> users);

        Task<IdentityResult> CreateUserAsync(CreateUserDto dto);

        Task<IdentityResult> UpdateUserRoleAsync(string userId, string role);

        Task<IdentityResult> DeleteUserAsync(string userId);
    }
}
