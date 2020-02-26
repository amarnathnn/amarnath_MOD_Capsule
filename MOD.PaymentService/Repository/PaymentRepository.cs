using Microsoft.EntityFrameworkCore;
using MOD.Entities;
using MOD.PaymentService.Models;
using System.Collections.Generic;
using System.Linq;

namespace MOD.PaymentService.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _dbContext;
        public PaymentRepository(PaymentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<PaymentDto> GetPayments(int userId,string role)
        {
            if (role.ToLowerInvariant() == "user")
            {
                var payments = _dbContext.Payment.Include(x => x.Mentor).Include(x => x.User).Include(x => x.Training).ThenInclude(x => x.Skill)
                    .Where(x => x.User.Userid == userId).ToList();
                return payments.Select(payment => new PaymentDto()
                {
                    Amount = payment.Amount,
                    Tax = payment.Tax,
                    paymentDate = payment.PaymentDate.ToShortDateString(),
                    Remarks = payment.Remarks,
                    TrainerName = payment.Mentor.MentorName,
                    TransactionType = payment.TransactionType,
                    Technology = payment.Training.Skill.Name
                }).ToList();
            }
            else if (role.ToLowerInvariant() == "mentor")
            {
                var payments = _dbContext.Payment.Include(x => x.Mentor).Include(x => x.User).Include(x => x.Training).ThenInclude(x => x.Skill)
                    .Where(x => x.Mentor.MentorId == userId).ToList();
                return payments.Select(payment => new PaymentDto()
                {
                    Amount = payment.Amount,
                    Tax = payment.Tax,
                    paymentDate = payment.PaymentDate.ToShortDateString(),
                    Remarks = payment.Remarks,
                    TrainerName = payment.Mentor.MentorName,
                    TransactionType = payment.TransactionType,
                    Technology = payment.Training.Skill.Name
                }).ToList();
            }
            return null;
        }


        public ResponseMessage InsertPayment(Payment payment)
        {
            var message = new ResponseMessage();
            var value = _dbContext.Add(payment);
            var insertedCount = Save();
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("Thank you! Your Payment completed successfully!");
            }
            else
            {
                message.SetErrorMessage("Error completing Payment");
            }
            return message;
        }



        public int Save()
        {
            var insertedCount = _dbContext.SaveChanges();
            return insertedCount;
        }

        public void UpdatePayment(Payment payment)
        {
            _dbContext.Entry(payment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

    }
}
