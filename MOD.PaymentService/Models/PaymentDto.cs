using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.PaymentService.Models
{
    public class PaymentDto
    {
        public string Technology { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public string TransactionType { get; set; }
        public string TrainerName { get; set; }
        public string Remarks { get; set; }
        public string paymentDate { get; set; }
    }
}
