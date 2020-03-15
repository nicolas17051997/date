using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataRange.BLL.Interfaces
{
   public interface IBaseService<T> where T: class
    {
        Task<T> Get(int id);
        Task<T> Create(T data);
    }
}
