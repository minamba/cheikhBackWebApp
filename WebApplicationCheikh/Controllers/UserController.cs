using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController : ControllerBase
    {

        [HttpGet("/users/sendMail")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Mail de contact")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> SendContactMailAsync()
        {
            return Ok();
        }
    }
}
