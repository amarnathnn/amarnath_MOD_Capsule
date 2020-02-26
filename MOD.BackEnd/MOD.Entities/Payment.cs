using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOD.Entities
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Remarks { get; set; }

    }
}
