using System;
using System.Threading.Tasks;

using DataRange.DAL.Repository;
using DataRange.BLL.Interfaces;

namespace DataRange.BLL.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public Task<T> Create(T data)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
