using BallastLane.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BallastLane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BallastLaneControllerBase
    {
        private readonly IStudentRepository _repository;
        public StudentController(IStudentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var res = await _repository.GetAllAsync();
            return res.Select(x => x.FirstName).ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
