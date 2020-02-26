using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.SearchService.Models
{
    public class MentorDto
    {
        public int MentorId { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public string Email { get; set; }
        public float YearsOfExperience { get; set; }
        public string LinkedInUrl { get; set; }
        public decimal Fees { get; set; }
        public int NoOfTrainingsCompleted { get; set; }
    }
}
