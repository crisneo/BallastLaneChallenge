using BallastLane.Application.Dto.User;
using BallastLane.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BallastLane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManagementService _userService;

        public UserController(IUserManagementService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateDto dto)
        {
            if (ModelState.IsValid)
            {
                return _userService.Authenticate(dto.Login, dto.Password) ? Ok() : NotFound();
            }
            return BadRequest();
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userService.RegisterUser(dto));
            }
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _userService.UpdateUser(dto));
            }
            return BadRequest();
        }

    }
}
