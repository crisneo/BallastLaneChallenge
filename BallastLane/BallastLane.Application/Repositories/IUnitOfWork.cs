using BallastLane.Application.Common;
using BallastLane.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<T> Save<T>(T entity) where T : BaseEntity;


        Task Rollback();
    }
}
