using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.Models;
using Microsoft.AspNetCore.Identity;

namespace IMS.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                dto.Email,
                dto.Password,
                dto.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
                return new LoginResponseDto { Success = true, Message = "Login successful" };

            if (result.IsLockedOut)
                return new LoginResponseDto { Success = false, Message = "Account locked" };

            return new LoginResponseDto { Success = false, Message = "Invalid credentials" };
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
