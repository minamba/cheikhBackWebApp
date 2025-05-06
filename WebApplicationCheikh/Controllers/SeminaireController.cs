using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    public class SeminaireController : Controller
    {
        [ApiController]
        [Route("Seminaire")]
        public class UserController : ControllerBase
        {

            [HttpGet("seminaire/users")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(SeminaireQueueViewModel), Description = "liste des elèves pour le prochain seminaire")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> GetSeminaireUsersAsync()
            {
                return Ok();
            }


            [HttpPost("registration/user")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Ajout d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> PostSeminaireUsersAsync([FromBody] SeminaireQueueViewModel model)
            {
                return NoContent();
            }


            [HttpDelete("registration/user/{id}")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> DeleteSeminaireUsersAsync([FromRoute] int Id)
            {
                return NoContent();
            }
        }
}
