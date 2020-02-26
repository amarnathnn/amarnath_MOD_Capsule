

using MOD.AuthenticationService.Models;

namespace MOD.SearchService.Repository
{
    public interface IAuthenticationRepository
    {
        LoginInfo Authenticate(string username, string password);


    }
}
