using CrisisManagementSystem.API.Application.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace CrisisManagementSystem.API.Application.IRepository
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(SystemUserDto systemUserDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);

        //if token is expried, this method will create a new token and will provide
        //to client. without having to login every 10 minutes
        Task<string> CreateRefreshToken();

        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
