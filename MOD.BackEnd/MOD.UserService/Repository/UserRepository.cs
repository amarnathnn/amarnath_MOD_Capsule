using Microsoft.EntityFrameworkCore;
using MOD.Entities;
using MOD.UserService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MOD.UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;
        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteUser(string username)
        {
            var user = _dbContext.Users.Find(username);
            _dbContext.Users.Remove(user);
            Save();
        }

        public User GetUser(string username)
        {
            return _dbContext.Users.Include(x => x.UserTrainings).ThenInclude(x => x.Mentor).SingleOrDefault(x => x.UserName == username);
        }

        public Mentor GetMentor(string mentorName)
        {
            return _dbContext.Mentors.Where(mentor => mentor.MentorName == mentorName).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public ResponseMessage InsertUser(User user)
        {
            var message = new ResponseMessage();
            if (user == null)
            {
                message.SetErrorMessage("Invalid data");
            }
            var userExist = _dbContext.Users.Where(x => string.Equals(x.UserName, user.UserName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (userExist.Count > 0)
            {
                message.SetErrorMessage("User already exists");
                return message;
            }
            user.RegistrationDate = DateTime.Now;
            user.Active = true;
            var value = _dbContext.Add(user);
            var insertedCount = Save();
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("User registered successfully");
            }
            else
            {
                message.SetErrorMessage("Error registering User");
            }
            return message;
        }


        public ResponseMessage InsertMentor(Mentor mentor)
        {
            var message = new ResponseMessage();
            if (mentor == null)
            {
                message.SetErrorMessage("Invalid data");
            }
            var mentorExist = _dbContext.Mentors.Where(x => string.Equals(x.MentorName, mentor.MentorName, StringComparison.InvariantCultureIgnoreCase)).ToList();
            if (mentorExist.Count > 0)
            {
                message.SetErrorMessage("mentor already exists");
                return message;
            }
            mentor.RegistrationDateTime = DateTime.Now;
            mentor.active = true;
            //mentor.MentorSkills.Add(new MentorSkill()
            //{
            //    SkillId = mentor.Technology
            //}
            //);
            //mentor.MentorCalendars.Add(new MentorCalendar()
            //{
            //    Timing = mentor.Timing
            //});

            var value = _dbContext.Add(mentor);
            var insertedCount = Save();
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("Mentor registered successfully");
            }
            else
            {
                message.SetErrorMessage("Error registering Mentor");
            }
            return message;

            //var value = _dbContext.Add(mentor);
            //var insertedCount = Save();
            //return insertedCount > 0 ? true : false;
        }
        public int Save()
        {
            var insertedCount = _dbContext.SaveChanges();
            return insertedCount;
        }

        public void UpdateUser(User user)
        {
            _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

    }
}
