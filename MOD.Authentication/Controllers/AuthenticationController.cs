using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MOD.AuthenticationService.Models;
using MOD.SearchService.Repository;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MOD.AuthenticationService.Controllers
{

    [Route("api/authentication")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
       
        [HttpGet,Route("authenticate")]
        public IActionResult Get(string username, string password)
        {
            var authData = _authenticationRepository.Authenticate(username, password);
            //var loginInfo = new LoginInfo()
            //{
            //    Role = authData?.Role,
            //    Token = authData?.Token,
            //    Username = username,
            //    UserId = authData?.UserId ?? 0
            //};
            return new OkObjectResult(authData);
        }
    }
}