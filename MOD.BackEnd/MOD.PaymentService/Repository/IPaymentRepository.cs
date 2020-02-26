using MOD.Entities;
using MOD.PaymentService.Models;
using System.Collections.Generic;

namespace MOD.PaymentService.Repository
{
    public interface IPaymentRepository
    {
      //  IEnumerable<User> GetUsers();
        List<PaymentDto> GetPayments(int userId,string role);
        ResponseMessage InsertPayment(Payment user);
        //bool InsertMentor(Mentor user);
        //void DeleteUser(string username);
        //void UpdateUser(User user);
       int Save();

    }
}
