using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builder.impl;
using ApplicationCheikh.Domain.Models;
using ApplicationCheikh.Domain.Repositories;
using ApplicationCheikh.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Registration")]
    public class RegistrationController : Controller
    {
            IRegistrationQueueViewModelBuilder _registrationQueueViewModelBuilder;

            public RegistrationController(IRegistrationQueueViewModelBuilder registrationQueueViewModelBuilder)
            {
            _registrationQueueViewModelBuilder = registrationQueueViewModelBuilder ?? throw new ArgumentNullException(nameof(registrationQueueViewModelBuilder), $"Cannot instantiate {GetType().Name}");
            }


            [HttpGet("/registrations")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<RegistrationQueueViewModel>), Description = "liste des potentiels futurs elèves")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> GetRegistrationsAsync()
            {
                var result = await _registrationQueueViewModelBuilder.GetRegistrationUsersQueue();
                return Ok(result);
            }


            [HttpPut("/registration")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "modification d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> PutRegistrationsAsync([FromBody] RegistrationQueue model)
            {
                var result = await _registrationQueueViewModelBuilder.UpdateRegistrationUserQueue(model.Id, model);
                return Ok(result);
            }


            [HttpPost("/registration")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> PostRegistrationsAsync([FromBody] RegistrationQueue model)
            {
                var result = await _registrationQueueViewModelBuilder.AddRegistrationUserQueue(model);
                return Ok(result);
            }


            [HttpDelete("/registration/{id}")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> DeleteRegistrationsAsync([FromRoute] int id)
            {
                var result = await _registrationQueueViewModelBuilder.DeleteRegistrationUserQueue(id);
                return Ok(result);
            }
    }
}
