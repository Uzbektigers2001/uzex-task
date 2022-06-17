using Microsoft.AspNetCore.Mvc;

namespace MockTask.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
