using CrisisManagementSystem.API.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace CrisisManagementSystem.API.IRepository
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(SystemUserDto systemUserDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
    }
}
