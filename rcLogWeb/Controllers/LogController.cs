using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogTransfers;
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

            LogTransfer logTransfer = new LogTransfer();

            logTransfer.Paginacao.PaginaInicial = 4;
            logTransfer.Paginacao.PaginaAtual = 6;
            logTransfer.Paginacao.PaginaFinal = 8;
            logTransfer.Paginacao.RegistrosPorPagina = 4;
            logTransfer.Paginacao.TotalPaginas = 15;
            logTransfer.Paginacao.TotalRegistros = 59;

            return View(logTransfer);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Sistemas()
        {
            ViewData["Usuario"] = UsuarioNome;

            SistemaTransfer sistemaTransfer = new SistemaTransfer();

            sistemaTransfer.Paginacao.PaginaInicial = 4;
            sistemaTransfer.Paginacao.PaginaAtual = 6;
            sistemaTransfer.Paginacao.PaginaFinal = 8;
            sistemaTransfer.Paginacao.RegistrosPorPagina = 4;
            sistemaTransfer.Paginacao.TotalPaginas = 15;
            sistemaTransfer.Paginacao.TotalRegistros = 59;

            return View(sistemaTransfer);
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
