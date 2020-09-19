using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogTransfers;
using rcLogWeb.Models;

namespace rcLogWeb.Controllers
{
    [Authorize]
    public class LogController : ControllerLog
    {
        public LogController(IHttpContextAccessor pAccessor)
            :base(pAccessor)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Usuario"] = UsuarioNome;

            LogModel logModel = new LogModel(httpContext);

            LogTransfer logReq = new LogTransfer();
            LogTransfer logRes = new LogTransfer();

            logRes = await logModel.Consultar(logReq);

            return View(logRes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(LogTransfer pLog)
        {
            ViewData["Usuario"] = UsuarioNome;

            LogModel logModel = new LogModel(httpContext);

            LogTransfer logRes = new LogTransfer();

            logRes = await logModel.Consultar(pLog);

            return View(logRes);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
