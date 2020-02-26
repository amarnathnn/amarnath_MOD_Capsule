using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOD.Entities
{
    public class Mentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MentorId { get; set; }
        public string MentorName { get; set; }
        public string Password { get; set; }
        public string LinkedInUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public bool ForceResetPassword { get; set; }
        public string RegCode { get; set; }
        public int YearsOfExperience { get; set; }
        public string EmailId { get; set; }
        public bool? active { get; set; }
        //public int Technology { get; set; }
        //public string Timing { get; set; }

        public  ICollection<MentorCalendar> MentorCalendars { get; set; }
        public IList<MentorSkill> MentorSkills { get; set; }
        public IList<Training> MentorTrainings { get; set; }
        public IList<Payment> MentorPayments { get; set; }

    }
}
