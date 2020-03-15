using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DataRange.BLL.Helper;
using DataRange.BLL.DTO;
using DataRange.BLL.Interfaces;

namespace DataRange.API.Controllers
{
    [ApiController]
    public class DateController: ControllerBase
    {
        private readonly IDateService _dateService;
        public DateController(IDateService dateService)
        {
            _dateService = dateService;
        }
        [HttpPost("AddDates")]
        public async Task<IActionResult> CreateDates(NoteDateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
        }
        [HttpPost("GetDates")]
        public async Task<IActionResult> GetDate(NoteDateViewModel model)
        {

        }
    }
}
