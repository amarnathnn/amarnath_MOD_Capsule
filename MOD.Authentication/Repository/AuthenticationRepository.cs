using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MOD.AuthenticationService;
using MOD.AuthenticationService.Models;
using MOD.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MOD.SearchService.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AuthenticationContext _dbContext;
        private string secret = null;
        public AuthenticationRepository(IOptions<Settings> settings, AuthenticationContext dbContext)
        {
            _dbContext = dbContext;
            secret = settings.Value.Secret;
        }

        public LoginInfo Authenticate(string username, string password)
        {
            LoginInfo loginInfo = new LoginInfo();
            bool isMentor = false;
            int userId = default(int);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                loginInfo.ErrorMessage = "Please input valid credentials.";
                return loginInfo;
            }
            var user = _dbContext.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                userId = user.Userid;
                loginInfo.UserDisplayName = user.FirstName + ", " + user.LastName;
            }
            else
            {
                var mentor = _dbContext.Mentors.SingleOrDefault(x => x.MentorName == username && x.Password == password);
                if (mentor == null)
                {
                    loginInfo.ErrorMessage = "Invalid Credentials.";
                    return loginInfo;
                    //return null;
                }
                isMentor = true;
                userId = mentor.MentorId;
                loginInfo.UserDisplayName = mentor.FirstName + ", " + mentor.LastName;
            }
            //// authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenValue = tokenHandler.WriteToken(token);

            loginInfo.Role = (isMentor) ? "mentor" : "user";
            loginInfo.Token = tokenValue;
            loginInfo.UserId = userId;
            loginInfo.Username = username;
            loginInfo.ErrorMessage =null;
            return loginInfo;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
