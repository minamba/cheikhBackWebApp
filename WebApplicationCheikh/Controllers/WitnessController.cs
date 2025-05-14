using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Api.Builders.impl;
using ApplicationCheikh.Api.Requests;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Witness")]
    public class WitnessController : Controller
    {
        IWitnessViewModelBuilder _witnessViewModelBuilder;

        public WitnessController(IWitnessViewModelBuilder witnessViewModelBuilder)
        {
            _witnessViewModelBuilder = witnessViewModelBuilder ?? throw new ArgumentNullException(nameof(witnessViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }



        [HttpPost("/witness")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> AddWitnessAsync([FromBody] Witness model)
        {

            var result = await _witnessViewModelBuilder.AddWitness(model);
            return Ok(result); 
        }

        [HttpGet("/witnesses")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(WitnessViewModel), Description = "liste temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetWitnessesAsync()
        {
            var result = await _witnessViewModelBuilder.GetWitnessAsync();
            return Ok(result);
        }


        [HttpPut("/witness")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Modif elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateWitnessAsync([FromBody] Witness model)
        {
            var result = await _witnessViewModelBuilder.UpdateWitness(model.Id, model);
            return Ok(result);
        }


        [HttpDelete("/witness/{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> DeleteWitnessAsync([FromRoute] int Id)
        {
            var result = await _witnessViewModelBuilder.DeleteWitness(Id);
            return Ok(result);
        }


    }
}
