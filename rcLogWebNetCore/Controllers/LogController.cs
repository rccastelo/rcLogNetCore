using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace rcLogWebNetCore.Controllers
{
    public class LogController : Controller
    {
        public LogController()
        {
        }

        [HttpPost]
        public IActionResult Filtro()
        {
            return View("Filtro");
        }

        [HttpPost]
        public IActionResult Filtrar()
        {
            return View("Lista");
        }

        [HttpPost]
        public IActionResult Listar()
        {
            return View("Lista");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
