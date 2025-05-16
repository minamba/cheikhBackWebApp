using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.Requests;
using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Services.imp;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.BillingPortal;
using Stripe.Checkout;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using SessionCreateOptions = Stripe.Checkout.SessionCreateOptions;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Payment")]
    public class PaymentController : Controller
    {
        IPaymentViewModelBuilder _paymentViewModelBuilder;
        private readonly IConfiguration _configuration;


        public PaymentController(IPaymentViewModelBuilder paymentViewModelBuilder, IConfiguration configuration)
        {
            _paymentViewModelBuilder = paymentViewModelBuilder ?? throw new ArgumentNullException(nameof(paymentViewModelBuilder), $"Cannot instantiate {GetType().Name}");
            _configuration = configuration;
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

            if (result.error == null)
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



        //STRIPE

        [HttpPost("/payment/stripe")]
        public IActionResult CreateCheckoutSession([FromBody] PaymentStripeRequest request)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "eur",
                        UnitAmount = (long)(request.Amount * 100), // Stripe attend des centimes
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = request.Description,
                        },
                    },
                    Quantity = 1,
                },
            },
                Mode = "payment",
                SuccessUrl = request.SuccessUrl,
                CancelUrl = request.CancelUrl,
                Metadata = request.Metadata
            };

            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Create(options);

            return Ok(new { sessionUrl = session.Url });
        }

    }
}
