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

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        Task<IdentityResult>  UserCreateAsync(UserCreateDto dto, string referer);

        Task<IdentityResult> UpdateUserRoleAsync(string userId, string role, string referer);

        Task<IdentityResult> DeleteUserAsync(string userId, string referer);
    }
}
