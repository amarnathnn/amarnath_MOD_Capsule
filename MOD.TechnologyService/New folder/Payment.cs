using MOD.SearchService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOD.TechnologyService.Model
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public int MentorId { get; set; }
        public Mentor Mentor { get; set; }
        public int TrainingId { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Remarks { get; set; }

    }
}
