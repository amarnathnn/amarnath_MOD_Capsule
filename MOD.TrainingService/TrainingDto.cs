using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TrainingService
{
    public class TrainingDto
    {
        public int TrainingId { get; set; }
        public int UserId { get; set; }
        public int MentorId { get; set; }
        public string MentorName { get; set; }
        public string UserName { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }
        public int Rating { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Timing { get; set; }
        public decimal Fees { get; set; }
    }
}
