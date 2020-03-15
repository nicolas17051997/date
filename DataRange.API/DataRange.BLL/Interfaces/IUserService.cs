using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataRange.BLL.DTO;

namespace DataRange.BLL.Interfaces
{
   public interface IUserService
    {
        Task CreateUser(UserViewModel model);
        Task Autenticate(UserViewModel model);
    }
}
