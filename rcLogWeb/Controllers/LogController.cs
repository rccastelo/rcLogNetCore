using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogWeb.Models;

namespace rcLogWeb.Controllers
{
    public class LogController : ControllerLog
    {
        public LogController(IHttpContextAccessor accessor)
            :base(accessor)
        {
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Usuario"] = UsuarioNome;

            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Sistemas()
        {
            ViewData["Usuario"] = UsuarioNome;

            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Sair()
        {
            AutenticaModel autenticaModel;

            autenticaModel = new AutenticaModel(httpContext);

            autenticaModel.Sair();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
