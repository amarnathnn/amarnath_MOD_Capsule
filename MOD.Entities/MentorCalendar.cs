using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.Entities
{
    public class MentorCalendar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MentorCalendarId { get; set; }
        public Mentor Mentor { get; set; }
        public int MentorId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Timing { get; set; }
    }
}
