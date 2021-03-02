using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcLogWebNetCore.Models;

namespace rcLogWebNetCore.Controllers
{
    public abstract class ControllerLog : Controller
    {
        // protected readonly IHttpContextAccessor httpContext;

        // protected string UsuarioNome;

        // protected ControllerLog(IHttpContextAccessor pAccessor)
        // {
        //     httpContext = pAccessor;

        //     UsuarioNome = "";

        //     ObterUsuario();
        // }

        // protected void ObterUsuario() {
        //     AutenticaModel autenticaModel;
        //     string usuario = "";

        //     try {
        //         autenticaModel = new AutenticaModel(httpContext);

        //         usuario = autenticaModel.ObterUsuario();
        //     } catch {
        //         usuario = "";
        //     } finally {
        //         autenticaModel = null;
        //     }

        //     UsuarioNome = usuario;
        // }
    }
}