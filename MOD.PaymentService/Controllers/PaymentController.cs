using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.Entities;
using MOD.PaymentService.Repository;

namespace MOD.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        // GET: api/User/5
        [Route("{userId:int}/{role}")]
        [HttpGet]
        public IActionResult GetPayments(int userId,string role)
        {
            var payments = _paymentRepository.GetPayments(userId,role);
            return new OkObjectResult(payments);
        }


        // POST: api/User
        [HttpPost]
        public IActionResult PostUser([FromBody] Payment payment)
        {
            var status = _paymentRepository.InsertPayment(payment);
            return new OkObjectResult(status);
        }
    }
    
}