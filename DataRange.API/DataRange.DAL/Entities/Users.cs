using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataRange.DAL.Entities
{
   public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<NoteDates> NoteDates { get; set; }
    }
}
