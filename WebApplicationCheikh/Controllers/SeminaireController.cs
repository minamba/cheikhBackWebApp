using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Seminaires")]
    public class SeminaireController : Controller
    {
        ISeminaireViewModelBuilder _seminaireViewModelBuilder;

        public SeminaireController(ISeminaireViewModelBuilder seminaireViewModelBuilder)
        {
            _seminaireViewModelBuilder = seminaireViewModelBuilder ?? throw new ArgumentNullException(nameof(seminaireViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }

        [HttpGet("seminaires")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<SeminaireViewModel>), Description = "liste des seminaires")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetSeminaireAsync()
        {
            var result = await _seminaireViewModelBuilder.GetSeminaires();
            return Ok(result);
        }


        [HttpPut("seminaire")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "mise à jour d'un seminaire")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateSeminaireAsync([FromBody] Seminaire model)
        {
            var result = await _seminaireViewModelBuilder.UpdateSeminaire(model.Id, model);
            return Ok(result);
        }



        [HttpPost("seminaire")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Ajout d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> PostSeminaireAsync([FromBody] Seminaire model)
        {
            var result = await _seminaireViewModelBuilder.AddSeminaire(model);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteSeminaireAsync([FromRoute] int Id)
        {
            var result = await _seminaireViewModelBuilder.DeleteSeminaire(Id);
            return Ok(result);
        }
    }
}
