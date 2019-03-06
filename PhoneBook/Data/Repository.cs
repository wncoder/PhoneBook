using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PhoneBook.Models;

namespace PhoneBook.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly ContactBookContext _dbContext;
        public Repository(ContactBookContext context)
        {
            _dbContext = context;
        }



        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity GetByID(int Id)
        {
            return _dbContext.Set<TEntity>().Find(Id);
        }

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var item = GetByID(Id);
            _dbContext.Set<TEntity>().Remove(item);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
