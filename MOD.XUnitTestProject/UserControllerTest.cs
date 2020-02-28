using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOD.UserService.Controllers;
using MOD.UserService.Repository;
using MOD.Logging;
using MOD.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MOD.XUnitTestProject
{
    public class UserControllerTest
    {      
        [Fact]
        public void Get_ReturnOkObjectResult_GetUserDetails()
        {
            // Arrange
            ILog _log = new LogNLog();
            var _userRepository = new UserRepository(DbContextMocker.GetUserContext());          
            var _userController = new UserController(_userRepository, _log);
            var testUser = GetTestUser();

            // Act
            var response = _userController.GetUserDetails("smith@gmail.com");

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsAssignableFrom<UserService.Models.UserDto>(okObjectResult.Value);
            Assert.Equal(testUser.UserName, data.UserName);            
        }
        [Fact]
        public void Get_ReturnOkObjectResult_GetMentorDetails()
        {
            // Arrange
            ILog _log = new LogNLog();
            var _userRepository = new UserRepository(DbContextMocker.GetUserContext());
            var _userController = new UserController(_userRepository, _log);
            var testMentor = GetTestMentor();

            // Act
            var response = _userController.GetMentorDetails("hari@gmail.com");

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsAssignableFrom<UserService.Models.MentorDto>(okObjectResult.Value);
            Assert.Equal("hari@gmail.com", data.MentorName);
        }
        private Mentor GetTestMentor()
        {
            Mentor testMentor = new Mentor();
            testMentor.MentorName = "santhoshparsi@gmail.com";
            testMentor.FirstName = "Santhosh";
            testMentor.LastName = "Parsi";
            testMentor.RegistrationDateTime = DateTime.Now;
            testMentor.active = true;
            testMentor.EmailId = "santhoshparsi@gmail.com";
            testMentor.ForceResetPassword = true;
            testMentor.Password = "test";
            testMentor.ContactNumber = "2349524234";
            testMentor.LinkedInUrl = "http://www.linkedIn.com/";
            testMentor.MentorSkills = GetTestMentorSkill();
            testMentor.YearsOfExperience = 14;
            testMentor.MentorCalendars = GetMentorCalendar();
            
            return testMentor;
        }
        private List<MentorSkill> GetTestMentorSkill()
        {
            List<MentorSkill> mentorSkills = new List<MentorSkill>();
            mentorSkills.Add(new MentorSkill()
            {
                SkillId = 4             
            });

            return mentorSkills;
        }
        private List<MentorCalendar> GetMentorCalendar()
        {
            List<MentorCalendar> mentorCalendars = new List<MentorCalendar>();
            mentorCalendars.Add(new MentorCalendar() {
                Timing = "2PM - 4PM"
            });
            return mentorCalendars;
        }
        private User GetTestUser()
        {
            User testUser = new User();
            testUser.UserName = "amarnathnn@gmail.com";
            testUser.FirstName = "Amarnath";
            testUser.LastName = "Naganathan";
            testUser.RegistrationDate = DateTime.Now;
            testUser.Active = true;
            testUser.EmailId = "amarnathnn@gmail.com";
            testUser.ForceResetPassword = true;
            testUser.Password = "test";

            return testUser;
        }
    }
}
