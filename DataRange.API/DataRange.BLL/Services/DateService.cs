using System;
using System.Collections.Generic;
using System.Text;
using DataRange.BLL.DTO;
using DataRange.BLL.Interfaces;
using DataRange.DAL.Repository;
using DataRange.DAL.Entities;
using System.Threading.Tasks;

namespace DataRange.BLL.Services
{
   public class DateService: BaseService<NoteDates>, IDateService
    {
        public DateService(IRepository<NoteDates> repository): base(repository)
        {

        }

        public Task CreateNote()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoteDateViewModel>> GetNotes()
        {
            throw new NotImplementedException();
        }
    }
}
