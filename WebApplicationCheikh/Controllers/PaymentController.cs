using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Payment")]
    public class PaymentController : Controller
    {
        IPaymentViewModelBuilder _paymentViewModelBuilder;

        public PaymentController(IPaymentViewModelBuilder paymentViewModelBuilder)
        {
            _paymentViewModelBuilder = paymentViewModelBuilder ?? throw new ArgumentNullException(nameof(paymentViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }


        [HttpGet("/payments")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PaymentViewModel>), Description = "liste des paiements")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetPaymentsAsync()
        {
            var result = await _paymentViewModelBuilder.GetPayments();
            return Ok(result);
        }


        [HttpPut("/payment")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PaymentViewModel), Description = "modification d'un paiement")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> PutPaymentAsync([FromBody] Payment model)
        {
            var result = await _paymentViewModelBuilder.UpdatePayment(model.Id, model);
            return Ok(result);
        }


        [HttpPost("/payment")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(PaymentViewModel), Description = "ajout d'un paiement")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> PostPaymentAsync([FromBody] Payment model)
        {
            var result = await _paymentViewModelBuilder.AddPayment(model);

            if(result.error == null)
                return Ok(result);
            else
                return BadRequest(result.error);
        }


        [HttpDelete("/payment/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un paiement")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeletePaymentAsync([FromRoute] int id)
        {
            var result = await _paymentViewModelBuilder.DeletePayment(id);
            return Ok(result);
        }
    }
}
