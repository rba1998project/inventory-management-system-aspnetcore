using IMS.BLL.DTOs;
using IMS.BLL.Interfaces;
using IMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace IMS.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AuthService> _logger;

        public AuthService(SignInManager<ApplicationUser> signInManager, ILogger<AuthService> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(
                dto.Email,
                dto.Password,
                dto.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation(
                        "User {UserEmail} logged in",
                        dto.Email);

                return new LoginResponseDto { Success = true, Message = "Login successful" };
            }

            if (result.IsLockedOut)
            {
                _logger.LogInformation(
                        "User {UserEmail} failed to log in due to account lockout",
                        dto.Email);

                return new LoginResponseDto { Success = false, Message = "Account locked" };
            }

            _logger.LogInformation(
                        "Failed login attempt for user {UserEmail} ",
                        dto.Email);

            return new LoginResponseDto { Success = false, Message = "Invalid credentials" };
        }

        public async Task LogoutAsync(string userEmail)
        {
            await _signInManager.SignOutAsync();

            _logger.LogInformation(
                        "User {UserEmail} logged out",
                        userEmail);
        }
    }
}
