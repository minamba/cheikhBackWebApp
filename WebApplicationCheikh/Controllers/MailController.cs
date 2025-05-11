using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Api.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Crypto.Macs;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Reflection.PortableExecutable;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("mail")]
    public class MailController : ControllerBase
    {
        IMailViewModelBuilder _mailViewModelBuilder;

        public MailController(IMailViewModelBuilder mailViewModelBuilder)
        {
            _mailViewModelBuilder = mailViewModelBuilder ?? throw new ArgumentNullException(nameof(mailViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }



        [HttpPost("/send/seminaire")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Mail pour le seminaire")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> SendSeminaireMailAsync([FromBody] MailRequest recipient)
        {

            var result = await _mailViewModelBuilder.SendMailSeminaire(recipient);
            return Ok(result);
        }

        [HttpPost("/send/seminaire/group")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "seminaire envoie de masse")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> SendSeminaireMailGroupAsync([FromBody] MailGroupRequest recipients)
        {

            var result = await _mailViewModelBuilder.SendMailGroupSeminaire(recipients);
            return Ok(result);
        }



        [HttpPost("/send/payment")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Mail pour le Paiement")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> SendPaymentMailAsync([FromBody] PaymentRequest recipient)
        {

            var result = await _mailViewModelBuilder.SendMailPayment(recipient);
            return Ok(result);
        }

        [HttpPost("/send/payment/Group")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Paiement envoie de masse")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> SendPaymentMailGroupAsync([FromBody] PaymentGroupRequest recipients)
        {

            var result = await _mailViewModelBuilder.SendMailGroupPayment(recipients);
            return Ok(result);
        }


        [HttpPost("/send/registration")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Engistrement pour entretien")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> SendRegistrationMailAsync()
        {

            return Ok();
        }

        [HttpPost("/send/registration/group")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Engistrement pour entretien")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> SendRegistrationMailGroupAsync()
        {

            return Ok();
        }



    }
}
