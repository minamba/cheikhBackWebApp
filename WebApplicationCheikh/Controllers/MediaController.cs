using Microsoft.AspNetCore.Mvc;

namespace ApplicationCheikh.Api.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
