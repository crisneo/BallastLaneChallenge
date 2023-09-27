using BallastLane.Application.Repositories;
using BallastLane.Domain.Entities;
using BallastLane.DataAccess.Contexts;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDataBaseContext _context;
        public StudentRepository(IDataBaseContext context)
        {
            _context = context;
        }
        public IQueryable<Student> Collection => _context.Students;

        public async Task<Student> CreateAsync(Student entity)
        {
            return (await _context.SaveOrUpdateEntity<Student>(entity));
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                await _context.Delete(entity);
            }
        }
        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveOrUpdateEntity<Student>(entity);
            }
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return (await _context.Students.Where(x => !x.IsDeleted).ToListAsync());
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return (await _context.Students.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id));
        }

        public async Task<Student> UpdateAsync(Student entity)
        {
            return (await _context.SaveOrUpdateEntity<Student>(entity));
        }
    }
}
