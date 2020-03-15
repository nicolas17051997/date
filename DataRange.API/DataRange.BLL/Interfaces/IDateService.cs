using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataRange.BLL.DTO;

namespace DataRange.BLL.Interfaces
{
   public interface IDateService
    {
        Task CreateNote();
        Task<IEnumerable<NoteDateViewModel>> GetNotes();
    }
}
