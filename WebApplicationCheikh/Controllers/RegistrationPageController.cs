using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Api.ViewModels;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("RegistrationPage")]
    public class RegistrationPageController : Controller
    {

        IRegistrationViewModelBuilder _registrationViewModelBuilder;

        public RegistrationPageController(IRegistrationViewModelBuilder registrationViewModelBuilder)
        {
            _registrationViewModelBuilder = registrationViewModelBuilder ?? throw new ArgumentNullException(nameof(registrationViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }

        [HttpGet("/registrationPage")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<RegistrationViewModel>), Description = "liste des registrations")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetRegistrationAsync()
        {
            var result = await _registrationViewModelBuilder.GetRegistration();
            return Ok(result);
        }


        [HttpPut("/registrationPage")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "mise à jour d'un registration")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateRegistrationAsync([FromBody] Registration model)
        {
            var result = await _registrationViewModelBuilder.UpdateRegistration(model.Id, model);
            return Ok(result);
        }

    }
}
