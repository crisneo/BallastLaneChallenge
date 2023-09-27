using BallastLane.Application.Common;
using BallastLane.Domain.Entities;
using BallastLane.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
