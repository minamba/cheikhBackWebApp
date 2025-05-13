using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    public class ImageController : Controller
    {
        IImageViewModelBuilder _imageViewModelBuilder;

        public ImageController(IImageViewModelBuilder imageViewModelBuilder)
        {
            _imageViewModelBuilder = imageViewModelBuilder ?? throw new ArgumentNullException(nameof(imageViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }



        [HttpPost("/images/image")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> AddImageAsync([FromBody] Image model)
        {

            var result = await _imageViewModelBuilder.AddImage(model);
            return Ok(result);
        }

        [HttpGet("/images")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ImageVIewModel), Description = "liste temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetImagesAsync()
        {
            var result = await _imageViewModelBuilder.GetImagesAsync();
            return Ok(result);
        }


        [HttpPut("/images/image")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Modif elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateImageAsync([FromBody] Image model)
        {
            var result = await _imageViewModelBuilder.UpdateImage(model.Id, model);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteImageAsync([FromRoute] int Id)
        {
            var result = await _imageViewModelBuilder.DeleteImage(Id);
            return Ok(result);
        }
    }
}
