using AutoMapper;
using BallastLane.Application.Dto.Course;
using BallastLane.Application.Dto.Student;
using BallastLane.Application.Repositories;
using BallastLane.Application.Services;
using BallastLane.DataAccess.Repositories;
using BallastLane.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BallastLane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggingService _logger;

        public CoursesController(IUnitOfWork unitOfWork, IMapper mapper, ILoggingService logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = await _unitOfWork.Repository<Course>().GetAllAsync();
            return Ok(courses.Select(x => _mapper.Map<CourseReadDto>(x)));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = await _unitOfWork.Repository<Course>().GetByIdAsync(id);
            return Ok(_mapper.Map<CourseReadDto>(course));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _unitOfWork.Repository<Course>().CreateAsync(_mapper.Map<Course>(dto)));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("createAndRegisterStudents")]
        public async Task<IActionResult> CreateAndRegister([FromBody] CourseCreateAndAddStudents dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var course = await _unitOfWork.Repository<Course>().CreateAsync(_mapper.Map<Course>(dto));
                    foreach (var studentId in dto.StudendsIds)
                    {
                        var student = await _unitOfWork.Repository<Student>().GetByIdAsync(studentId);
                        student.CourseId = course.Id;
                        await _unitOfWork.Save<Student>(student);
                    }
                    return Ok();
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                }

            }
            return BadRequest();
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Repository<Course>().DeleteAsync(id);
            return Ok();
        }
    }
}
