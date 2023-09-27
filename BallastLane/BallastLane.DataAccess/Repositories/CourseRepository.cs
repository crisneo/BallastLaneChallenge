using BallastLane.Application.Repositories;
using BallastLane.DataAccess.Contexts;
using BallastLane.Domain.Entities;
using BallastLane.Domain.Entities.Authentication;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDataBaseContext _context;
        public CourseRepository(IDataBaseContext context)
        {
            _context = context;
        }

        public IQueryable<Course> Collection => _context.Courses;


        public async Task<Course> CreateAsync(Course entity)
        {
            return (await _context.SaveOrUpdateEntity<Course>(entity));
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                await _context.Delete(entity);
            }
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return (await _context.Courses.Where(x => !x.IsDeleted).ToListAsync());
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return (await _context.Courses.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == id));
        }

        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _context.SaveOrUpdateEntity<Course>(entity);
            }
        }

        public async Task<Course> UpdateAsync(Course entity)
        {
            return (await _context.SaveOrUpdateEntity<Course>(entity));
        }
    }
}
