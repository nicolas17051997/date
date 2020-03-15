using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataRange.DAL.Repository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(int id);
        Task<T> Insert(T entity);
        Task SaveChanges();
    }
}
