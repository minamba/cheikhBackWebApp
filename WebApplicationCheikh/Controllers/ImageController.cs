using Microsoft.AspNetCore.Mvc;

namespace ApplicationCheikh.Api.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
