using BallastLane.Application.Repositories;
using BallastLane.DataAccess.Contexts;
using BallastLane.Domain.Entities;
using BallastLane.Domain.Entities.Authentication;
using NHibernate.Id.Insert;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataBaseContext _context;
        public UserRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<User> Collection => _context.Users;

        public async Task<User> CreateAsync(User entity)
        {
            return (await _context.SaveOrUpdateEntity<User>(entity));
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                await _context.Delete(entity);
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            return (await _context.Users.Where(x => !x.IsDeleted).ToListAsync());
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return (await _context.Users.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id));
        }

        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveOrUpdateEntity<User>(entity);
            }
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return (await _context.SaveOrUpdateEntity<User>(entity));
        }
    }
}
