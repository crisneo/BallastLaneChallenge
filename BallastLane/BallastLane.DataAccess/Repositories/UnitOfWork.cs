﻿using BallastLane.Application.Common;
using BallastLane.Application.Repositories;
using BallastLane.DataAccess.Contexts;
using BallastLane.Domain.Common;
using BallastLane.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            //todo: implement disposing
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();
            var type = typeof(T).Name;



            if (!_repositories.ContainsKey(type))
            {
                //Tech Debt:  we could implement a more generic way to inject repositories in this section
                //var repositoryType = typeof(IGenericRepository<>);
                //var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);
                IGenericRepository<T> repositoryInstance = null;
                switch (type)
                {
                    case "Course": repositoryInstance = (IGenericRepository<T>)new CourseRepository(_dbContext); break;
                    case "Student":
                        repositoryInstance = (IGenericRepository<T>)new StudentRepository(_dbContext);
                        break; ;
                    case "User":
                        repositoryInstance = (IGenericRepository<T>)new UserRepository(_dbContext);
                        break; ;
                    default: break;
                }

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
