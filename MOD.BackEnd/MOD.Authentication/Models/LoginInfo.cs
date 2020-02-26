using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.AuthenticationService.Models
{
    public class LoginInfo
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
