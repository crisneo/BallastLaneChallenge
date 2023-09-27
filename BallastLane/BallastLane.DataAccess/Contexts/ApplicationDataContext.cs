using BallastLane.Domain.Common;
using BallastLane.Domain.Entities;
using BallastLane.Domain.Entities.Authentication;
using NHibernate;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BallastLane.DataAccess.Contexts
{
    public class ApplicationDataContext : IDataBaseContext
    {
        private readonly ISession _session;
        private ITransaction _transaction;
        public ApplicationDataContext(ISession session, ITransaction transaction = null)
        {
            _session = session;
            _transaction = transaction;
        }

        public IQueryable<Student> Students => _session.Query<Student>();
        public IQueryable<Course> Courses => _session.Query<Course>();

        public IQueryable<User> Users => _session.Query<User>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }


        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            await _session.DeleteAsync(entity);
        }


        public async Task<T> SaveOrUpdateEntity<T>(T entity) where T : BaseEntity
        {
            await _session.SaveOrUpdateAsync(entity);
            _session.Flush();
            return entity;
        }

        public async Task Delete(BaseEntity entity)
        {
            await _session.DeleteAsync(entity);
            _session.Flush();
        }
    }
}
