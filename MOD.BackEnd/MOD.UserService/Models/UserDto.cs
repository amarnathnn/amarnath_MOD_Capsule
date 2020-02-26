using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.UserService.Models
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string RegistrationDate { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
    }
}
