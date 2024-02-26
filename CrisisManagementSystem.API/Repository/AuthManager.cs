using AutoMapper;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.DTOs.User;
using CrisisManagementSystem.API.IRepository;
using Microsoft.AspNetCore.Identity;

namespace CrisisManagementSystem.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SystemUser> _userManager;

        public AuthManager(IMapper mapper , UserManager<SystemUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isValidUser = false;
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);

                if (user == null)
                {
                    return default;
                }

                isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

                if (!isValidUser)
                {
                    return default;
                }
            }
            catch (Exception)
            {
            }
            return isValidUser;
        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(SystemUserDto systemUserDto)
        {
            var user = _mapper.Map<SystemUser>(systemUserDto);

            user.UserName = systemUserDto.Email;

            //password .netcore has a mechanism to hash it and save
            var result = await _userManager.CreateAsync(user,systemUserDto.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }
    }
}
