using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("PaymentPage")]
    public class PaymentPageController : Controller
    {
        IPaymentPageViewModelBuilder _paymentPageViewModelBuilder;

        public PaymentPageController(IPaymentPageViewModelBuilder paymentPageViewModelBuilder)
        {
            _paymentPageViewModelBuilder = paymentPageViewModelBuilder ?? throw new ArgumentNullException(nameof(paymentPageViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }


        [HttpGet("/paymentpage")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PaymentPageViewModel>), Description = "liste des potentiels futurs elèves")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetPaymentAsync()
        {
            var result = await _paymentPageViewModelBuilder.GetPaymentPg();
            return Ok(result);
        }


        [HttpPut("/paymentpage")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "modification d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> PutPaymentPagesAsync([FromBody] PaymentPg model)
        {
            var result = await _paymentPageViewModelBuilder.UpdatePaymentPg(model.Id, model);
            return Ok(result);
        }
    }
}
