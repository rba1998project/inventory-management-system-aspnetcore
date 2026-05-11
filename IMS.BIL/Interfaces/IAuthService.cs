using IMS.BLL.DTOs;
using IMS.Models;

namespace IMS.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginDto dto);

        Task LogoutAsync();
    }
}
