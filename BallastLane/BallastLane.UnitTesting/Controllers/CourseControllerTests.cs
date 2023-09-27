using AutoMapper;
using BallastLane.Application.Common;
using BallastLane.Application.Dto.Course;
using BallastLane.Application.Dto.Student;
using BallastLane.Application.Repositories;
using BallastLane.Application.Services;
using BallastLane.Domain.Entities;
using BallastLane.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace BallastLane.UnitTesting.Controllers
{
    public class CourseControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetCoursesTest()
        {
            var mockCourseRepo = new Mock<ICourseRepository>();
            mockCourseRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Course>());
            var mockRepository = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.Repository<Course>()).Returns(mockCourseRepo.Object);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<StudentReadDto>(It.IsAny<Student>())).Returns(new StudentReadDto());
            var mockLogger = new Mock<ILoggingService>();
            mockLogger.Setup(x => x.Log(It.IsAny<ILogMessage>())).Callback((ILogMessage mesg) => { });

            var controller = new CoursesController(mockRepository.Object, mapperMock.Object, mockLogger.Object);

            var actionResult = await controller.Get();
            var contentResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
        }

        [Test]
        public async Task PostCourseTest()
        {
            // This version uses a mock UrlHelper.
            var courseMock = new Course()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Code = "Test",
            };
            var mockCourseRepo = new Mock<ICourseRepository>();
            mockCourseRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<Course>());
            mockCourseRepo.Setup(x => x.CreateAsync(It.IsAny<Course>()))
               .ReturnsAsync(courseMock);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<Course>(It.IsAny<CourseCreateDto>())).Returns(courseMock);

            var mockRepository = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.Repository<Course>()).Returns(mockCourseRepo.Object);

            var mockLogger = new Mock<ILoggingService>();
            mockLogger.Setup(x => x.Log(It.IsAny<ILogMessage>())).Callback((ILogMessage mesg) => { });


            var controller = new CoursesController(mockRepository.Object, mapperMock.Object, mockLogger.Object);

            // Act
            var actionResult = await controller.Post(new CourseCreateDto());
            var contentResult = actionResult as OkObjectResult;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Value);
            var courseResult = contentResult.Value as Course;
            Assert.AreEqual(courseMock.Name, courseResult.Name);
            Assert.AreEqual(courseMock.Description, courseResult.Description);
        }
    }
}
