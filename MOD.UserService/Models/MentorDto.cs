using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.UserService.Models
{
    public class MentorDto
    {
        public int MentorId { get; set; }
        public string MentorName { get; set; }
        public string LinkedInUrl { get; set; }
        public string RegistrationDate { get; set; }
        public int YearsOfExperience { get; set; }
        public string EmailId { get; set; }
    }
}

