using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogTransfers;
using rcLogWeb.Models;

namespace rcLogWeb.Controllers
{
    public class HomeController : ControllerLog
    {
        public HomeController(IHttpContextAccessor pAccessor)
            :base(pAccessor)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            string returnUrl = httpContext.HttpContext.Request.Query["ReturnUrl"];

            if(!String.IsNullOrEmpty(returnUrl)) {
                ViewData["Bloqueio"] = "Acesso Negado";
            } else {
                ViewData["Bloqueio"] = "";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(AutenticaTransfer pAutentica)
        {
            AutenticaModel autenticaModel;
            AutenticaTransfer autentica;

            try {
                autenticaModel = new AutenticaModel(httpContext);

                autentica = await autenticaModel.Autenticar(pAutentica);
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
                return RedirectToAction("Index", "Log");
            }
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
