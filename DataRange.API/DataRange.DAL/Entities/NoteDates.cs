using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataRange.DAL.Entities
{
   public class NoteDates
    {
        [Key]
        public int DataId { get; set; }
        public DateTime FirstData { get; set; }
        public DateTime LastData { get; set; }

        public int UserId { get; set; }
        public Users Users { get; set; }
    }
}
