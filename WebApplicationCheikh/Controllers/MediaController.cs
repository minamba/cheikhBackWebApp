using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Medias")]
    public class MediaController : Controller
    {
        IMediaViewModelBuilder _mediaViewModelBuilder;

        public MediaController(IMediaViewModelBuilder mediaViewModelBuilder)
        {
            _mediaViewModelBuilder = mediaViewModelBuilder ?? throw new ArgumentNullException(nameof(mediaViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }



        [HttpPost("/media")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> AddMediaAsync([FromBody] Media model)
        {

            var result = await _mediaViewModelBuilder.AddMedia(model);
            return Ok(result);
        }

        [HttpGet("/medias")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(MediaViewModel), Description = "liste temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetMediasAsync()
        {
            var result = await _mediaViewModelBuilder.GetMediasAsync();
            return Ok(result);
        }


        [HttpPut("/media")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Modif elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateMediaAsync([FromBody] Media model)
        {
            var result = await _mediaViewModelBuilder.UpdateMedia(model.Id, model);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteMediaAsync([FromRoute] int Id)
        {
            var result = await _mediaViewModelBuilder.DeleteMedia(Id);
            return Ok(result);
        }
    }
}
