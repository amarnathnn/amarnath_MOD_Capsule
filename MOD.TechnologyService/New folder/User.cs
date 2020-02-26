using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TechnologyService.Model
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Userid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string  RegCode { get; set; }
        public bool ForceResetPassword { get; set; }
        public bool Active { get; set; }
        public IList<Training> UserTrainings { get; set; }
    }
}
