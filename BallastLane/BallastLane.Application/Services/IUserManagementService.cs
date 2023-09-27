using BallastLane.Application.Dto.User;
using BallastLane.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Services
{
    public interface IUserManagementService
    {
        bool Authenticate(string user, string password);
        Task<User> RegisterUser(UserCreateDto dto);
        Task<User> UpdateUser(UserUpdateDto dto);
    }
}
