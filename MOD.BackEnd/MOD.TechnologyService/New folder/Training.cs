using MOD.SearchService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TechnologyService.Model
{
    public class Training
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingId { get; set; }
        public int UserId { get; set; }
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public User User { get; set; }
        public int SkillId { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }
        public int Rating { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
