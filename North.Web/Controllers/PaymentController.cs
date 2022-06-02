using Microsoft.AspNetCore.Mvc;
using North.Businesss.Services.Payment;

namespace North.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Route("guvenli-odeme")]
        public IActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        [Route("taksit-kontrol")]
        public IActionResult CheckInstallments(string cardNumber, decimal price)
        {
            if (string.IsNullOrEmpty(cardNumber))
                return BadRequest();
            var result = _paymentService.CheckInstallments(cardNumber, price);
            return Ok(result);
        }

    }
}
