using Microsoft.AspNetCore.Mvc;

namespace ApplicationCheikh.Api.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
