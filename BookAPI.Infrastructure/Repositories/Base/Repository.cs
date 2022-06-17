using BookAPI.DAL.Repository.Interfaces;
using BookAPI.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BookContext _dbContext;

        public Repository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            var result = _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            
            var result = _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public T DeleteSoft(T entity)
        {

            var result = _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();    
        }

        public T Update(T entity)
        {
            var result = _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
