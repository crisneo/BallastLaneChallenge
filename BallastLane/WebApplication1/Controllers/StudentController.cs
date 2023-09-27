﻿using AutoMapper;
using BallastLane.Application.Dto.Student;
using BallastLane.Application.Repositories;
using BallastLane.Domain.Entities;
using BallastLane.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        public StudentController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _repository.GetAllAsync();
            return Ok(res.Select(x => _mapper.Map<StudentReadDto>(x)).ToList());
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            return Ok(_mapper.Map<StudentReadDto>(student));
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var student = await _repository.CreateAsync(_mapper.Map<Student>(dto));
            return Ok(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] StudentUpdateDto value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            //await  _repository.DeleteAsync()
        }
    }
}