using CrisisManagementSystem.API.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace CrisisManagementSystem.API.IRepository
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(SystemUserDto systemUserDto);
        Task<bool> Login(LoginDto loginDto);
    }
}
