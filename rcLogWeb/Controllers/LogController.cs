using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogTransfers;
using rcLogWeb.Models;

namespace rcLogWeb.Controllers
{
    public class LogController : ControllerLog
    {
        public LogController(IHttpContextAccessor pAccessor)
            :base(pAccessor)
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
