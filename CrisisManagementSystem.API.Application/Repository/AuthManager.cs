using AutoMapper;
using CrisisManagementSystem.API.DataLayer;
using CrisisManagementSystem.API.Application.DTOs.User;
using CrisisManagementSystem.API.Application.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CrisisManagementSystem.API.Application.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<SystemUser> _userManager;
        private readonly IConfiguration _configuration;
        private SystemUser _user;
        private const string _loginProvider = "CrisisManagmentAPI";
        private const string _refreshToken = "RefreshToken";


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

                _user = await _userManager.FindByEmailAsync(loginDto.Email);
               isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

                if (_user == null || !isValidUser)
                {
                    return null;
                }

               

                var token = await GenerateToken();

                return new AuthResponseDto()
                {
                    UserId = _user.Id,
                    Token = token,
                    RefreshToken = await CreateRefreshToken()
                };
        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(SystemUserDto systemUserDto)
        {
            _user = _mapper.Map<SystemUser>(systemUserDto);

            _user.UserName = systemUserDto.Email;

            //password .netcore has a mechanism to hash it and save
            var result = await _userManager.CreateAsync(_user, systemUserDto.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }

            return result.Errors;
        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub,_user.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email,_user.Email),
                new Claim("uid",_user.Id)
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


        public async Task<string> CreateRefreshToken()
        {
            //removing old token from database
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);

            // creating new token 
            var newRefreshedToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);

            // set the token in database
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshedToken);

            return newRefreshedToken;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims
                                       .ToList()
                                       .FirstOrDefault(
                                        q =>
                                        q.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email
                                        )?.Value;

            _user = await _userManager.FindByNameAsync(username);

            if (_user == null || _user.Id != request.UserId)
            {
                return null;
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user,_loginProvider, _refreshToken,request.RefreshToken);

            if(isValidRefreshToken)
            {
                var token = await GenerateToken();

                return new AuthResponseDto
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);

            return null;
        }
    }
}
