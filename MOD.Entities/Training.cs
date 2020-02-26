using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOD.Entities
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
        public Skill Skill { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }
        public int Rating { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Timing { get; set; }
    }
}
