using AutoMapper;
using BallastLane.Application.Dto.User;
using BallastLane.Application.Repositories;
using BallastLane.Application.Services;
using BallastLane.Domain.Entities.Authentication;
using BallastLane.Infrastructure.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Infrastructure.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserManagementService(IUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public bool Authenticate(string user, string password)
        {
            var encryptedPassword = EncryptHelper.EncryptString(password, _configuration["securityKey"]);
            return _repository.Collection.FirstOrDefault(x => x.Login == user && x.Password == encryptedPassword) != null;
        }

        public async Task<User> RegisterUser(UserCreateDto dto)
        {
            var encryptedPassword = EncryptHelper.EncryptString(dto.Password, _configuration["securityKey"]);
            dto.Password = encryptedPassword;
            return (await _repository.CreateAsync(_mapper.Map<User>(dto)));
        }

        public async Task<User> UpdateUser(UserUpdateDto dto)
        {
            var encryptedPassword = EncryptHelper.EncryptString(dto.Password, _configuration["securityKey"]);
            dto.Password = encryptedPassword;
            return (await _repository.UpdateAsync(_mapper.Map<User>(dto)));
        }
    }
}
