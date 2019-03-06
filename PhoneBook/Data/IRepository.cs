using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Data
{
    public interface IRepository<TEntity> 
        where TEntity: class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetByID(int Id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
    }
}
