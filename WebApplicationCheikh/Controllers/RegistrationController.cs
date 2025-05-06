using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    public class RegistrationController : Controller
    {
        [ApiController]
        [Route("Registration")]
        public class UserController : ControllerBase
        {

            [HttpGet("registration/users")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "liste des potentiels futurs elèves")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> GetRegistrationsAsync()
            {
                return Ok();
            }


            [HttpPost("registration/user")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Ajout d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> PostRegistrationsAsync([FromBody] RegistrationQueueViewModel model)
            {
                return Ok();
            }


            [HttpDelete("registration/user/{id}")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> DeleteRegistrationsAsync([FromRoute] int id)
            {
                return Ok();
            }
        }
    }
}
