using BallastLane.Application.Common;
using BallastLane.Application.Repositories;
using BallastLane.DataAccess.Contexts;
using BallastLane.Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataBaseContext _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(IDataBaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Dispose()
        {
            //todo: implement
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();
            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(IGenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<T>)_repositories[type];
        }

        public async Task Rollback()
        {
            await _dbContext.Rollback();
        }

        public async Task<T> Save<T>(T entity) where T : BaseEntity
        {
            return (await _dbContext.SaveOrUpdateEntity<T>(entity));
        }
    }
}
