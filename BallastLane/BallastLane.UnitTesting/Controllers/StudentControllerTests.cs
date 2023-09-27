using AutoMapper;
using BallastLane.Application.Dto.Student;
using BallastLane.Application.Dto.User;
using BallastLane.Application.Repositories;
using BallastLane.Application.Services;
using BallastLane.Domain.Entities;
using BallastLane.Domain.Entities.Authentication;
using Microsoft.AspNetCore.Mvc;
using Moq;

using WebApplication1.Controllers;

namespace BallastLane.UnitTesting.Controllers
{
    public class StudentControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetStudentsTest()
        {
            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<Student>());
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<StudentReadDto>(It.IsAny<Student>())).Returns(new StudentReadDto());

            var controller = new StudentController(mockRepository.Object, mapperMock.Object);

            var actionResult = await controller.Get();
            var contentResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
        }

        [Test]
        public async Task PostStudentsTest()
        {
            // This version uses a mock UrlHelper.
            var mockStudent = new Student()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "Test",
                Code = "Test",
            };

            var mockRepository = new Mock<IStudentRepository>();
            mockRepository.Setup(x => x.CreateAsync(It.IsAny<Student>()))
                .ReturnsAsync(mockStudent);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Student>(It.IsAny<StudentCreateDto>())).Returns(mockStudent);

            var controller = new StudentController(mockRepository.Object, mapperMock.Object);

            // Act
            var actionResult = await controller.Post(new StudentCreateDto());
            var contentResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
            var studentResult = contentResult.Value as Student;
            Assert.AreEqual(mockStudent.FirstName, studentResult.FirstName);
            Assert.AreEqual(mockStudent.LastName, studentResult.LastName);
        }
    }
}
