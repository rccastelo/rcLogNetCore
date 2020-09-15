using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogTransfers;
using rcLogWeb.Models;

namespace rcLogWeb.Controllers
{
    [Authorize]
    public class SistemaController : ControllerLog
    {
        public SistemaController(IHttpContextAccessor pAccessor)
            :base(pAccessor)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Usuario"] = UsuarioNome;

            SistemaModel sistemaModel = new SistemaModel(httpContext);

            SistemaTransfer sistemaReq = new SistemaTransfer();
            SistemaTransfer sistemaRes = new SistemaTransfer();

            sistemaReq.Paginacao.RegistrosPorPagina = 3;
            // sistemaReq.Paginacao.PaginaAtual = 2;
            // sistemaReq.Sistema = new rcLogEntities.SistemaEntity();
            // sistemaReq.Sistema.Codigo = "cod";
            // sistemaReq.Filtro.Descricao = "desc";

            sistemaRes = await sistemaModel.Consultar(sistemaReq);

            return View(sistemaRes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(SistemaTransfer pSistema)
        {
            ViewData["Usuario"] = UsuarioNome;

            SistemaModel sistemaModel = new SistemaModel(httpContext);

            SistemaTransfer sistemaReq = new SistemaTransfer(pSistema);
            SistemaTransfer sistemaRes = new SistemaTransfer();

            sistemaReq.Paginacao.RegistrosPorPagina = 3;
            // sistemaReq.Paginacao.PaginaAtual = 2;
            // sistemaReq.Sistema = new rcLogEntities.SistemaEntity();
            // sistemaReq.Sistema.Codigo = "cod";
            // sistemaReq.Filtro.Descricao = "desc";

            sistemaRes = await sistemaModel.Consultar(sistemaReq);

            return View(sistemaRes);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}