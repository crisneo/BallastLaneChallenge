using BallastLane.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Common
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IQueryable<T> Collection { get; }

        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
