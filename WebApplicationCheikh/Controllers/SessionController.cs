using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Session")]
    public class SessionController : Controller
    {
        ISessionViewModelBuilder _sessionViewModelBuilder;

        public SessionController(ISessionViewModelBuilder sessionViewModelBuilder)
        {
            _sessionViewModelBuilder = sessionViewModelBuilder ?? throw new ArgumentNullException(nameof(sessionViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }



        [HttpPost("/session")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> AddSessionAsync([FromBody] Session model)
        {

            var result = await _sessionViewModelBuilder.AddSessions(model);
            return Ok(result);
        }

        [HttpGet("/sessions")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(SessionViewModel), Description = "liste temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetSessionsAsync()
        {
            var result = await _sessionViewModelBuilder.GetSessionsAsync();
            return Ok(result);
        }


        [HttpPut("/session")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Modif elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateSessionAsync([FromBody] Session model)
        {
            var result = await _sessionViewModelBuilder.UpdateSession(model.Id, model);
            return Ok(result);
        }


        [HttpDelete("/session/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteSessionAsync([FromRoute] int Id)
        {
            var result = await _sessionViewModelBuilder.DeleteSession(Id);
            return Ok(result);
        }
    }
}
