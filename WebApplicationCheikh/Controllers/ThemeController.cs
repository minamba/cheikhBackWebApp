using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    public class ThemeController : Controller
    {
        IThemeViewModelBuilder _themeViewModelBuilder;

        public ThemeController(IThemeViewModelBuilder themeViewModelBuilder)
        {
            _themeViewModelBuilder = themeViewModelBuilder ?? throw new ArgumentNullException(nameof(themeViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }



        [HttpPost("/themes/theme")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> AddThemeAsync([FromBody] Theme model)
        {

            var result = await _themeViewModelBuilder.AddTheme(model);
            return Ok(result);
        }

        [HttpGet("/themes")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ThemeViewModel), Description = "liste temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetThemesAsync()
        {
            var result = await _themeViewModelBuilder.GetThemesAsync();
            return Ok(result);
        }


        [HttpPut("/themes/theme")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Modif elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateThemeAsync([FromBody] Theme model)
        {
            var result = await _themeViewModelBuilder.UpdateTheme(model.Id, model);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteThemeAsync([FromRoute] int Id)
        {
            var result = await _themeViewModelBuilder.DeleteTheme(Id);
            return Ok(result);
        }
    }
}
