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
    [Route("Home")]
    public class HomeController : Controller
    {
        IHomeViewModelBuilder _homeViewModelBuilder;

        public HomeController(IHomeViewModelBuilder homeViewModelBuilder)
        {
            _homeViewModelBuilder = homeViewModelBuilder ?? throw new ArgumentNullException(nameof(homeViewModelBuilder), $"Cannot instantiate {GetType().Name}");
        }




        [HttpPut("/homes/home")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "Modif elève")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> UpdateHomeAsync([FromBody] Home model)
        {
            var result = await _homeViewModelBuilder.UpdateHome(model.Id, model);
            return Ok(result);
        }




        [HttpGet("/homes")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(HomeViewModel), Description = "liste temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> GetHomesAsync()
        {
            var result = await _homeViewModelBuilder.GetHomeAsync();
            return Ok(result);
        }



        [HttpPost("/home")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string), Description = "ajout temoignage")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "An unexpected error occurred")]
        public async Task<IActionResult> AddHomeAsync([FromBody] HomeRequest model)
        {

            var home = new Home()
            {
                IdBanner = model.IdBanner,
                IdImage = model.IdImage,
                IdMedia = model.IdMedia,
                Title = model.Title,
            };

            var result = await _homeViewModelBuilder.AddHome(home);
            return Ok(result);
        }


    }
}
