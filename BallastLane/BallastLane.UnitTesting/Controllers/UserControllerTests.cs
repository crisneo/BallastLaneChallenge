using AutoMapper;
using BallastLane.Application.Dto.Student;
using BallastLane.Application.Dto.User;
using BallastLane.Application.Repositories;
using BallastLane.Application.Services;
using BallastLane.Domain.Entities;
using BallastLane.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace BallastLane.UnitTesting.Controllers
{
    public class UserControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task AuthenticateUserTest()
        {
            var userServiceMock = new Mock<IUserManagementService>();
            userServiceMock.Setup(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            var controller = new UserController(userServiceMock.Object);

            var actionResult = controller.Authenticate(new AuthenticateDto());
            var contentResult = actionResult as OkResult;

            Assert.IsNotNull(contentResult);
            userServiceMock.Verify(x => x.Authenticate(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
