using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataRange.BLL.DTO;
using DataRange.BLL.Interfaces;
using DataRange.DAL.Repository;
using DataRange.DAL.Entities;


namespace DataRange.BLL.Services
{
    public class UserService : BaseService<Users>,  IUserService
    {
        public UserService( IRepository<Users> repository ): base(repository)
        {

        }
        public Task Autenticate(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task CreateUser(UserViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
