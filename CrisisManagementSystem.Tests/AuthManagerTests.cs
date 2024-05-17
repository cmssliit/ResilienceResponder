using AutoMapper;
using CrisisManagementSystem.API.Application.DTOs.User;
using CrisisManagementSystem.API.Application.IRepository;
using CrisisManagementSystem.API.Application.Repository;
using CrisisManagementSystem.API.DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisisManagementSystem.Tests
{
    public class AuthManagerTests
    {
        private readonly AuthManager _authManager;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<UserManager<SystemUser>> _mockUserManager;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public AuthManagerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockUserManager = MockUserManager<SystemUser>();
            _mockConfiguration = new Mock<IConfiguration>();

            _authManager = new AuthManager(
                _mockMapper.Object,
                _mockUserManager.Object,
                _mockConfiguration.Object
            );
        }

        private static Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(
                store.Object, null, null, null, null, null, null, null, null);
            return mgr;
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsAuthResponseDto()
        {
            // Arrange
            var loginDto = new LoginDto { Email = "admin@example.com", Password = "password" };
            var user = new SystemUser { UserName = loginDto.Email, Email = loginDto.Email };

            _mockUserManager.Setup(um => um.FindByEmailAsync(loginDto.Email)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.CheckPasswordAsync(user, loginDto.Password)).ReturnsAsync(true);
            _mockConfiguration.Setup(c => c["JwtSettings:Key"]).Returns("supersecretkey!");
            _mockConfiguration.Setup(c => c["JwtSettings:Issuer"]).Returns("issuer");
            _mockConfiguration.Setup(c => c["JwtSettings:Audience"]).Returns("audience");
            _mockConfiguration.Setup(c => c["JwtSettings:DurationInMinutes"]).Returns("60");

            // Act
            var result = await _authManager.Login(loginDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.UserId);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var loginDto = new LoginDto { Email = "admin@example.com", Password = "wrongpassword" };
            var user = new SystemUser { UserName = loginDto.Email, Email = loginDto.Email };

            _mockUserManager.Setup(um => um.FindByEmailAsync(loginDto.Email)).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.CheckPasswordAsync(user, loginDto.Password)).ReturnsAsync(false);

            // Act
            var result = await _authManager.Login(loginDto);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task RegisterUser_ValidUser_ReturnsNoErrors()
        {
            // Arrange
            var systemUserDto = new SystemUserDto { Email = "newuser@example.com", Password = "password" };
            var user = new SystemUser { UserName = systemUserDto.Email, Email = systemUserDto.Email };

            _mockMapper.Setup(m => m.Map<SystemUser>(systemUserDto)).Returns(user);
            _mockUserManager.Setup(um => um.CreateAsync(user, systemUserDto.Password)).ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(um => um.AddToRoleAsync(user, "User")).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authManager.RegisterUser(systemUserDto);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task RegisterUser_InvalidUser_ReturnsErrors()
        {
            // Arrange
            var systemUserDto = new SystemUserDto { Email = "newuser@example.com", Password = "password" };
            var user = new SystemUser { UserName = systemUserDto.Email, Email = systemUserDto.Email };
            var identityErrors = new List<IdentityError> { new IdentityError { Description = "Error" } };

            _mockMapper.Setup(m => m.Map<SystemUser>(systemUserDto)).Returns(user);
            _mockUserManager.Setup(um => um.CreateAsync(user, systemUserDto.Password)).ReturnsAsync(IdentityResult.Failed(identityErrors.ToArray()));

            // Act
            var result = await _authManager.RegisterUser(systemUserDto);

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task VerifyRefreshToken_ValidToken_ReturnsAuthResponseDto()
        {
            // Arrange
            var authResponseDto = new AuthResponseDto { Token = "validToken", UserId = "userId", RefreshToken = "validRefreshToken" };
            var user = new SystemUser { UserName = "admin@example.com", Id = "userId" };

            _mockUserManager.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.VerifyUserTokenAsync(user, It.IsAny<string>(), It.IsAny<string>(), authResponseDto.RefreshToken)).ReturnsAsync(true);
            _mockConfiguration.Setup(c => c["JwtSettings:Key"]).Returns("supersecretkey!");
            _mockConfiguration.Setup(c => c["JwtSettings:Issuer"]).Returns("issuer");
            _mockConfiguration.Setup(c => c["JwtSettings:Audience"]).Returns("audience");
            _mockConfiguration.Setup(c => c["JwtSettings:DurationInMinutes"]).Returns("60");

            // Act
            var result = await _authManager.VerifyRefreshToken(authResponseDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.UserId);
        }

        [Fact]
        public async Task VerifyRefreshToken_InvalidToken_ReturnsNull()
        {
            // Arrange
            var authResponseDto = new AuthResponseDto { Token = "invalidToken", UserId = "userId", RefreshToken = "invalidRefreshToken" };
            var user = new SystemUser { UserName = "admin@example.com", Id = "userId" };

            _mockUserManager.Setup(um => um.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.VerifyUserTokenAsync(user, It.IsAny<string>(), It.IsAny<string>(), authResponseDto.RefreshToken)).ReturnsAsync(false);

            // Act
            var result = await _authManager.VerifyRefreshToken(authResponseDto);

            // Assert
            Assert.Null(result);
        }
    }
}
