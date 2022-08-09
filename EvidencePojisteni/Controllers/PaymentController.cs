using Braintree;
using EvidencePojisteni.Classes;
using EvidencePojisteni.Data;
using EvidencePojisteni.Extensions;
using EvidencePojisteni.Models.AssignedInsurances;
using EvidencePojisteni.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EvidencePojisteni.Controllers
{
    [ExceptionsToMessageFilter]
    public class PaymentController : Controller
    {
        private readonly IBraintreeService _braintreeService;
        private readonly ApplicationDbContext _context;

        public PaymentController(IBraintreeService braintreeService, ApplicationDbContext context)
        {
            _braintreeService = braintreeService;
            _context = context;
        }

        public async Task<IActionResult> Index(int assignedInsuranceId)
        {
            var gateway = _braintreeService.GetGateway();
            var clientToken = gateway.ClientToken.Generate();
            ViewBag.ClientToken = clientToken;

            var assignedInsurance = await _context.AssignedInsurance
               .Include(a => a.Insurance)
               .Include(a => a.Insured)
               .FirstOrDefaultAsync(m => m.AssignedInsuranceId == assignedInsuranceId);

            return View(assignedInsurance);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nonce, int assignedInsuranceId)
        {
            var assignedInsurance = await _context.AssignedInsurance
               .Include(a => a.Insurance)
               .Include(a => a.Insured)
               .FirstOrDefaultAsync(m => m.AssignedInsuranceId == assignedInsuranceId);
            var gateway = _braintreeService.GetGateway();
            var request = new TransactionRequest
            {
                Amount = Convert.ToDecimal(assignedInsurance.Value),
                PaymentMethodNonce = nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                assignedInsurance.Paid = true;
                _context.SaveChanges();
                this.AddFlashMessage(new FlashMessage("Pojištění bylo zaplaceno", FlashMessageType.Success));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                throw new Exception(result.Message);
            }
        }
    }
}
