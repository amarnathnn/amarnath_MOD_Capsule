using MOD.TechnologyService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.SearchService.Models
{
    public class Mentor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MentorId { get; set; }
        public string MentorName { get; set; }
        public string LinkedInUrl { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string RegCode { get; set; }
        public int YearsOfExperience { get; set; }
        public bool? active { get; set; }

        public ICollection<MentorCalendar> MentorCalendars { get; set; }
        public IList<MentorSkill> MentorSkill { get; set; }
        public IList<Training> MentorTraining { get; set; }
        public IList<Payment> MentorPayments { get; set; }

    }
}
