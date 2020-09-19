using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogEntities;
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

            sistemaRes = await sistemaModel.Consultar(sistemaReq);

            return View(sistemaRes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(SistemaTransfer pSistema)
        {
            ViewData["Usuario"] = UsuarioNome;

            SistemaModel sistemaModel = new SistemaModel(httpContext);

            SistemaTransfer sistemaRes = new SistemaTransfer();

            sistemaRes = await sistemaModel.Consultar(pSistema);

            if(pSistema != null) {
                if(pSistema.Sistema != null) {
                    if(pSistema.Sistema.Id > 0) {
                        sistemaRes.Sistema = new SistemaEntity();
                        sistemaRes.Sistema.Id = pSistema.Sistema.Id;
                    }
                }
            }

            return View(sistemaRes);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}