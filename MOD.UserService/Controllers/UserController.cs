using Microsoft.AspNetCore.Mvc;
using MOD.Entities;
using MOD.UserService.Models;
using MOD.UserService.Repository;
using System.Collections.Generic;
using MOD.Logging;
namespace MOD.UserService.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        ILog _logger;
        public UserController(IUserRepository userRepository, ILog logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        // GET: api/User/5
        [Route("getuser")]
        [HttpGet]
        public IActionResult GetUserDetails(string username)
        {
            _logger.Information("Get User Details Started");
            var user = _userRepository.GetUser(username);
            try
            {
                UserDto userDto = new UserDto()
                {
                    ContactNumber = user.ContactNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RegistrationDate = user.RegistrationDate.ToShortDateString(),
                    UserId = user.Userid,
                    UserName = user.UserName,
                    EmailId = user.EmailId
                };
                _logger.Information("Get User Details End");
                return new OkObjectResult(userDto);
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Route("mentordetails")]
        public IActionResult GetMentorDetails(string mentorName)
        {
            try
            {
                _logger.Information("Get Mentor Details Started");
                var mentor = _userRepository.GetMentor(mentorName);

                MentorDto mentorDto = new MentorDto()
                {
                    MentorId = mentor.MentorId,
                    EmailId = mentor?.EmailId,
                    LinkedInUrl = mentor?.LinkedInUrl,
                    MentorName = mentor?.MentorName,
                    RegistrationDate = mentor?.RegistrationDateTime.ToShortDateString(),
                    YearsOfExperience = mentor?.YearsOfExperience ?? 0
                };
                _logger.Information("Get Mentor Details Started");
                return new OkObjectResult(mentorDto);

            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);
                return StatusCode(500, "Internal Server Error");
            }

        }


        // POST: api/User
        [Route("register")]
        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            try
            {
                _logger.Information("Register User Started");
                var status = _userRepository.InsertUser(user);
                _logger.Information("Register User End");
                return new OkObjectResult(status);
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);
                return StatusCode(500, "Internal Server Error");
            }

        }

        [Route("registermentor")]
        [HttpPost]
        public IActionResult PostMentor([FromBody] Mentor mentor)
        {
            try
            {
                _logger.Information("Register Mentor Started");
                var status = _userRepository.InsertMentor(mentor);

                _logger.Information("Register Mentor End");
                return new OkObjectResult(status);

            }
            catch (System.Exception ex)
            {
                _logger.Error(ex.StackTrace);
                return StatusCode(500, ex.StackTrace);

            }

        }

       
    }
}
