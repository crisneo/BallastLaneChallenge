using AutoMapper;
using BallastLane.Application.Dto.Course;
using BallastLane.Application.Dto.Student;
using BallastLane.Application.Dto.User;
using BallastLane.Domain.Entities;
using BallastLane.Domain.Entities.Authentication;

namespace BallastLane.WebAPI.MapperProfiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Course, CourseDto>();
            CreateMap<User, UserDto>();
        }
    }
}
