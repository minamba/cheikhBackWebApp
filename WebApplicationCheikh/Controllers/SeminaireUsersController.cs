using ApplicationCheikh.Api.Builder;
using ApplicationCheikh.Api.Builder.impl;
using ApplicationCheikh.Api.Builders;
using ApplicationCheikh.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics.Eventing.Reader;
using System.Net;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("SeminaireUsers")]
    public class SeminaireUsersController : Controller
    {
            ISeminaireQueueViewModelBuilder _seminaireQueueViewModelBuilder;


            public SeminaireUsersController(ISeminaireQueueViewModelBuilder seminaireQueueViewModelBuilder)
            {
                _seminaireQueueViewModelBuilder = seminaireQueueViewModelBuilder ?? throw new ArgumentNullException(nameof(seminaireQueueViewModelBuilder), $"Cannot instantiate {GetType().Name}");
            }


            [HttpGet("SeminaireUsers")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(SeminaireQueueViewModel), Description = "liste des elèves pour le prochain seminaire")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> GetSeminaireUsersAsync()
            {
                var result = await _seminaireQueueViewModelBuilder.GetSeminaireUsersQueue();
                return Ok(result);
            }


            [HttpPut("SeminaireUser")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Ajout d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> UpdateSeminaireUsersAsync([FromBody] SeminaireQueue model)
            {
                var result = await _seminaireQueueViewModelBuilder.UpdateSeminaireUserQueue(model.Id, model);
                return Ok(result);
            }



            [HttpPost("SeminaireUser")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Ajout d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> PostSeminaireUsersAsync([FromBody] SeminaireQueue model)
            {
                var result = await _seminaireQueueViewModelBuilder.AddSeminaireUserQueue(model);

                
                if(result.error == null)
                    return Ok(result);
                else//
                    return BadRequest(result.error);
            }


            [HttpDelete("{id}")]
            [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Suppression d'un potentiel futur elève")]
            [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
            public async Task<IActionResult> DeleteSeminaireUsersAsync([FromRoute] int Id)
            {
                var result = await _seminaireQueueViewModelBuilder.DeleteSeminaireUserQueue(Id);
                return Ok(result);
            }
    }
}
