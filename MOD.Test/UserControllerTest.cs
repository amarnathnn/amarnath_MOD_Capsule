using System;
using Xunit;
using MOD.UserService.Repository;
using MOD.UserService.Controllers;
using MOD.UserService;
using MOD.Logging;
using MOD.Entities;
using System.Collections.Generic;
using MOD.UserService.Models;

namespace MOD.Test
{
    public class UserControllerTest
    {
        private readonly UserController _userService;
        private readonly IUserRepository _userRepository;
        ILog _logger;
        public UserControllerTest(UserContext context)
        {
            _userService = new UserController(_userRepository, _logger);
        }
        [Fact]
        public void TestGet()
        {
            var OkResult = _userService.GetUserDetails("amarnathnn@gmail.com");
            var items = Assert.IsType<List<User>>(OkResult);
            Assert.Single(items);
        }
    }
}
