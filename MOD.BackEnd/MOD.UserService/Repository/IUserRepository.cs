using MOD.Entities;
using System.Collections.Generic;

namespace MOD.UserService.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(string username);
        Mentor GetMentor(string mentorname);
        ResponseMessage InsertUser(User user);
        ResponseMessage InsertMentor(Mentor user);
        void DeleteUser(string username);
        void UpdateUser(User user);
        int Save();

    }
}
