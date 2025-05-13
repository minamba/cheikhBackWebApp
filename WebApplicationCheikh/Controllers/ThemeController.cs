using Microsoft.AspNetCore.Mvc;

namespace ApplicationCheikh.Api.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
