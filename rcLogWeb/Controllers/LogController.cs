using Microsoft.AspNetCore.Mvc;

namespace rcLogWeb.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sistemas()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
