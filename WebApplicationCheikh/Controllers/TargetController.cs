using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    public class TargetController : Controller
    {
        ITargetViewModelBuilder _targetViewModelBuilder;

        public TargetController(ITargetViewModelBuilder targetViewModelBuilder)
        {
            _targetViewModelBuilder = targetViewModelBuilder ?? throw new ArgumentNullException(nameof(targetViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }



        [HttpPost("/targets/target")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> AddTargetAsync([FromBody] Target model)
        {

            var result = await _targetViewModelBuilder.AddTarget(model);
            return Ok(result);
        }

        [HttpGet("/targets")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(TargetViewModel), Description = "liste temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetTargetsAsync()
        {
            var result = await _targetViewModelBuilder.GetTargetsAsync();
            return Ok(result);
        }


        [HttpPut("/targets/target")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Modif elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateTargetAsync([FromBody] Target model)
        {
            var result = await _targetViewModelBuilder.UpdateTarget(model.Id, model);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteTargetAsync([FromRoute] int Id)
        {
            var result = await _targetViewModelBuilder.DeleteTarget(Id);
            return Ok(result);
        }
    }
}
