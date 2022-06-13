using BookAPI.DAL.DataAccess;
using BookAPI.DAL.Entities.BaseEntity;
using BookAPI.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ContextFactory _dbFactory;
        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public Repository(ContextFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public void Add(T entity)
        {

            if (typeof(IEntityBase).IsAssignableFrom(typeof(T)))
            {
                ((IEntityBase)entity).CreatedDate = DateTime.UtcNow;
            }
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {

            if (typeof(IEntityBase).IsAssignableFrom(typeof(T)))
            {
                ((IEntityBase)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else
                DbSet.Remove(entity);
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
