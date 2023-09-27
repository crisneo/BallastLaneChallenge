using BallastLane.Domain.Common;
using BallastLane.Domain.Entities;
using BallastLane.Domain.Entities.Authentication;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.DataAccess.Contexts
{
    public interface IDataBaseContext
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();

        IQueryable<Student> Students { get; }
        IQueryable<Course> Courses { get; }
        IQueryable<User> Users { get; }

        Task<T> SaveOrUpdateEntity<T>(T entity) where T : BaseEntity;

        Task Delete(BaseEntity entity);

    }
}
