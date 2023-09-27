using AutoMapper;
using BallastLane.Application.Dto.User;
using BallastLane.Application.Repositories;
using BallastLane.Application.Services;
using BallastLane.Domain.Entities.Authentication;
using BallastLane.Infrastructure.Services;
using BallastLane.Infrastructure.Tools;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.UnitTesting.Services
{
    public class UserManagementServiceTests
    {
        private IUserManagementService _userManagementService;
        private Mock<IUserRepository> _userRepoMock;

        [SetUp]
        public void Setup()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _userRepoMock.Setup(x => x.CreateAsync(It.IsAny<User>())).ReturnsAsync(new User());
            _userRepoMock.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(new User());
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<User>(It.IsAny<UserCreateDto>())).Returns(new User());
            mapperMock.Setup(x => x.Map<User>(It.IsAny<UserUpdateDto>())).Returns(new User());
            var inMemorySettings = new Dictionary<string, string> {
                    {"securityKey", "kljsdkkdlo4454GG00155sajuklmbkdl"},
                    {"SectionName:SomeKey", "SectionValue"},
                };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();
            _userManagementService = new UserManagementService(_userRepoMock.Object, mapperMock.Object, configuration);
        }

        [Test]
        public async Task TestRegisterUser()
        {
            var dto = new UserCreateDto()
            {
                Email = "user@mail.com",
                Password = "123456a",
                Login = "user"
            };
            var res = await _userManagementService.RegisterUser(dto);
            Assert.IsNotNull(res);
            _userRepoMock.Verify(x => x.CreateAsync(It.IsAny<User>()), Times.Once);

        }

        [Test]
        public async Task TestUpdateUser()
        {
            var dto = new UserUpdateDto()
            {
                Email = "user@mail.com",
                Password = "123456a",
                Login = "user"
            };
            var res = await _userManagementService.UpdateUser(dto);
            Assert.IsNotNull(res);
            _userRepoMock.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public async Task TestAuthenticateUser()
        {
            var userName = "user";
            var password = "myPassword";
            var passwordEncryped = EncryptHelper.EncryptString(password, "kljsdkkdlo4454GG00155sajuklmbkdl");
            var users = new List<User>();
            users.Add(new User { Login = userName, Password = passwordEncryped });
            _userRepoMock.Setup(x => x.Collection).Returns(users.AsQueryable());
            var res = _userManagementService.Authenticate(userName, password);
            Assert.IsTrue(res);
        }
    }
}
