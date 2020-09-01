using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogTransfers;
using rcLogWeb.Models;

namespace rcLogWeb.Controllers
{
    public class HomeController : ControllerLog
    {
        public HomeController(IHttpContextAccessor accessor)
            :base(accessor)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            AutenticaTransfer autenticaTransfer = new AutenticaTransfer(); 

            return View(autenticaTransfer);
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(AutenticaTransfer autenticaTransfer)
        {
            AutenticaModel autenticaModel;
            AutenticaTransfer autentica;

            try {
                autenticaModel = new AutenticaModel(httpContext);

                autentica = await autenticaModel.Autenticar(autenticaTransfer);
            } catch (Exception ex) {
                autentica = new AutenticaTransfer();

                autentica.Validacao = false;
                autentica.Erro = true;
                autentica.IncluirMensagem("Erro em AutenticaController Consulta [" + ex.Message + "]");
            } finally {
                autenticaModel = null;
            }

            if (autentica.Erro || !autentica.Validacao || !autentica.Autenticado) {
                return View("Index", autentica);
            } else {
                ViewData["Usuario"] = UsuarioNome;
                
                return RedirectToAction("Index", "Log");
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
