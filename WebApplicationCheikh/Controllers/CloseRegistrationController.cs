using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("CloseInscription")]
    public class CloseRegistrationController : Controller
    {
        ICloseRegistrationViewModelBuilder _closeregistrationModelBuilder;

        public CloseRegistrationController(ICloseRegistrationViewModelBuilder closeRegistrationViewModelBuilder)
        {
            _closeregistrationModelBuilder = closeRegistrationViewModelBuilder ?? throw new ArgumentNullException(nameof(closeRegistrationViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }


        [HttpGet("/closeinscription")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CloseRegistrationViewModel>), Description = "liste des potentiels futurs elèves")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetCloseRegistrationsAsync()
        {
            var result = await _closeregistrationModelBuilder.GetCloseRegistration();
            return Ok(result);
        }


        [HttpPut("/closeinscription")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "modification d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> PutCloseRegistrationsAsync([FromBody] CloseRegistration model)
        {
            var result = await _closeregistrationModelBuilder.UpdateCloseRegistration(model.Id, model);
            return Ok(result);
        }
    }
}
