using AutoMapper;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.DTOs.User;
using CrisisManagementSystem.API.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrisisManagementSystem.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthManager(IMapper mapper , 
                           UserManager<SystemUser> userManager,
                           IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            bool isValidUser = false;
            
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
               isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

                if (user == null || !isValidUser)
                {
                    return null;
                }

               

                var token = await GenerateToken(user);

                return new AuthResponseDto()
                {
                    UserId = user.Id,
                    Token = token
                };
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

        private async Task<string> GenerateToken(SystemUser systemUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(systemUser);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(systemUser);

            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,systemUser.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,systemUser.Email),
                new Claim("uid",systemUser.Id)
            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            ); ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
