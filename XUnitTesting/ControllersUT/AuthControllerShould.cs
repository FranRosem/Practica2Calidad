using AutoMapper;
using FilmFranchiseAPI.Controllers;
using FilmFranchiseAPI.Data;
using FilmFranchiseAPI.Models.Security;
using FilmFranchiseAPI.Services.Security;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTesting.ControllersUT
{
    public class AuthControllerShould
    {
        [Fact]
        public async Task RegisterUserAsync()
        {
            var registerModel = new RegisterViewModel()
            {
                Email = "yonpol@hotmail.com",
                Password = "yonpol123",
                ConfirmPassword = "yonpol123"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "User created successfully!",
                IsSuccess = true
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.RegisterUserAsync(registerModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.RegisterAsync(registerModel);
            var okResult = result as OkObjectResult;
            var responseValues = okResult.Value as UserManagerResponse;

            Assert.NotNull(okResult);
            Assert.True(responseValues.IsSuccess);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task BadRequestRegisterUserAsync()
        {
            var registerModel = new RegisterViewModel()
            {
                Email = "yonpol@hotmail.com",
                Password = "yonpol123",
                ConfirmPassword = "yonpol123"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "Confirm password doesn't match the password",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.RegisterUserAsync(registerModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.RegisterAsync(registerModel);
            var badResult = result as BadRequestObjectResult;
            var responseValues = badResult.Value as UserManagerResponse;

            Assert.NotNull(badResult);
            Assert.False(responseValues.IsSuccess);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task InvalidModelRegisterUserAsync()
        {
            var registerModel = new RegisterViewModel()
            {
                Email = "yonpol",
                Password = "yonpol123",
                ConfirmPassword = "yonpol"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "Confirm password doesn't match the password",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.RegisterUserAsync(registerModel));

            var authController = new AuthController(userServiceMock.Object);
            authController.ModelState.AddModelError("", "");

            var result = await authController.RegisterAsync(registerModel);
            var badResult = result as BadRequestObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal("Some properties are not valid", badResult.Value);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task CreateRolenAsync()
        {
            var roleModel = new CreateRoleViewModel()
            {
                Name = "Morales",
                NormalizedName = "Moraleada"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "User created successfully!",
                IsSuccess = true
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.CreateRoleAsync(roleModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.CreateRolenAsync(roleModel);
            var okResult = result as OkObjectResult;
            var responseValues = okResult.Value as UserManagerResponse;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.True(responseValues.IsSuccess);
        }

        [Fact]
        public async Task BadRequestCreateRolenAsync()
        {
            var roleModel = new CreateRoleViewModel()
            {
                Name = "Morales",
                NormalizedName = "Moraleada"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "Role did not create",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.CreateRoleAsync(roleModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.CreateRolenAsync(roleModel);
            var badResult = result as BadRequestObjectResult;
            var responseValues = badResult.Value as UserManagerResponse;

            Assert.NotNull(badResult);
            Assert.False(responseValues.IsSuccess);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task InvalidModelCreateRolenAsync()
        {
            var roleModel = new CreateRoleViewModel()
            {
                Name = "Morales",
                NormalizedName = "Moraleada"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "Role did not create",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.CreateRoleAsync(roleModel));

            var authController = new AuthController(userServiceMock.Object);
            authController.ModelState.AddModelError("", "");

            var result = await authController.CreateRolenAsync(roleModel);
            var badResult = result as BadRequestObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal("Some properties are not valid", badResult.Value);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task CreateUserRolenAsync()
        {
            var userRoleModel = new CreateUserRoleViewModel()
            {
                UserId = "1",
                RoleId = "1"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "Role assigned",
                IsSuccess = true
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.CreateUserRoleAsync(userRoleModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.CreateUserRolenAsync(userRoleModel);
            var okResult = result as OkObjectResult;
            var responseValues = okResult.Value as UserManagerResponse;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.True(responseValues.IsSuccess);
        }

        [Fact]
        public async Task BadRequestCreateUserRolenAsync()
        {
            var userRoleModel = new CreateUserRoleViewModel()
            {
                UserId = "1",
                RoleId = "1"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "user does not exist",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.CreateUserRoleAsync(userRoleModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.CreateUserRolenAsync(userRoleModel);
            var badResult = result as BadRequestObjectResult;
            var responseValues = badResult.Value as UserManagerResponse;

            Assert.NotNull(badResult);
            Assert.False(responseValues.IsSuccess);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task InvalidModelCreateUserRolenAsync()
        {
            var userRoleModel = new CreateUserRoleViewModel()
            {
                UserId = "1",
                RoleId = "1"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "user does not exist",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.CreateUserRoleAsync(userRoleModel));

            var authController = new AuthController(userServiceMock.Object);
            authController.ModelState.AddModelError("", "");

            var result = await authController.CreateUserRolenAsync(userRoleModel);
            var badResult = result as BadRequestObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal("Some properties are not valid", badResult.Value);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task LoginAsync()
        {
            var loginModel = new LoginViewModel()
            {
                Email = "yonpol@hotmail.com",
                Password = "yonpol123"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "token",
                IsSuccess = true,
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.LoginUserAsync(loginModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.LoginAsync(loginModel);
            var okResult = result as OkObjectResult;
            var responseValues = okResult.Value as UserManagerResponse;

            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.True(responseValues.IsSuccess);
        }

        [Fact]
        public async Task BadRequestLoginAsync()
        {
            var loginModel = new LoginViewModel()
            {
                Email = "yonpol",
                Password = "yonpol123"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "There is no user with that Email address",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.LoginUserAsync(loginModel)).ReturnsAsync(userResponse);

            var authController = new AuthController(userServiceMock.Object);
            var result = await authController.LoginAsync(loginModel);
            var badResult = result as BadRequestObjectResult;
            var responseValues = badResult.Value as UserManagerResponse;

            Assert.NotNull(badResult);
            Assert.False(responseValues.IsSuccess);
            Assert.Equal(400, badResult.StatusCode);
        }

        [Fact]
        public async Task InvalidModelLoginAsync()
        {
            var loginModel = new LoginViewModel()
            {
                Email = "yonpol",
                Password = "yonpol123"
            };
            var userResponse = new UserManagerResponse
            {
                Token = "There is no user with that Email address",
                IsSuccess = false
            };

            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.LoginUserAsync(loginModel));

            var authController = new AuthController(userServiceMock.Object);
            authController.ModelState.AddModelError("", "");

            var result = await authController.LoginAsync(loginModel);
            var badResult = result as BadRequestObjectResult;

            Assert.NotNull(badResult);
            Assert.Equal("Some properties are not valid", badResult.Value);
            Assert.Equal(400, badResult.StatusCode);
        }
    }
}