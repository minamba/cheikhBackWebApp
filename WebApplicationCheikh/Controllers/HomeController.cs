using Microsoft.AspNetCore.Mvc;

namespace ApplicationCheikh.Api.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : Controller
    {


        [HttpGet]
        public async Task<IActionResult> GetHomeAsync()
        {
            return Ok();
        }
    }
}
