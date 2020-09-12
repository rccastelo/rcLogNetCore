using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcLogWebApi.Models;
using rcLogTransfers;

namespace rcLogWebApi.Controllers
{
    // [Authorize]
    [Route("[controller]")]
    public class SistemaController : ControllerBase
    {
        // [HttpGet("{id}")]
        // public IActionResult ConsultarPorId(int id)
        // {
        //     SistemaModel sistemaModel;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaModel = new SistemaModel();

        //         if (id > 0) {
        //             sistema = sistemaModel.ConsultarPorId(id);
        //         } else {
        //             sistema = null;
        //         }
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaController ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         sistemaModel = null;
        //     }

        //     sistema.TratarLinks();

        //     if (sistema.Erro || !sistema.Validacao) {
        //         return BadRequest(sistema);
        //     } else {
        //         return Ok(sistema);
        //     }
        // }

        // [HttpGet]
        // public IActionResult Listar()
        // {
        //     SistemaModel sistemaModel;
        //     SistemaTransfer sistemaLista;

        //     try {
        //         sistemaModel = new SistemaModel();

        //         sistemaLista = sistemaModel.Consultar(new SistemaTransfer());
        //     } catch (Exception ex) {
        //         sistemaLista = new SistemaTransfer();

        //         sistemaLista.Validacao = false;
        //         sistemaLista.Erro = true;
        //         sistemaLista.IncluirMensagem("Erro em SistemaController Listar [" + ex.Message + "]");
        //     } finally {
        //         sistemaModel = null;
        //     }

        //     sistemaLista.TratarLinks();

        //     if (sistemaLista.Erro || !sistemaLista.Validacao) {
        //         return BadRequest(sistemaLista);
        //     } else {
        //         return Ok(sistemaLista);
        //     }
        // }

        [HttpPost("lista")]
        public IActionResult Consultar(SistemaTransfer pSistema)
        {
            SistemaModel sistemaModel;
            SistemaTransfer sistemaLista;

            try {
                sistemaModel = new SistemaModel();

                sistemaLista = sistemaModel.Consultar(pSistema);
            } catch (Exception ex) {
                sistemaLista = new SistemaTransfer();

                sistemaLista.Validacao = false;
                sistemaLista.Erro = true;
                sistemaLista.IncluirMensagem("Erro em SistemaController Consultar [" + ex.Message + "]");
            } finally {
                sistemaModel = null;
            }

            sistemaLista.TratarLinks();

            if (sistemaLista.Erro || !sistemaLista.Validacao) {
                return BadRequest(sistemaLista);
            } else {
                return Ok(sistemaLista);
            }
        }

        // [HttpPost]
        // public IActionResult Incluir(SistemaTransfer pSistema)
        // {
        //     SistemaModel sistemaModel;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaModel = new SistemaModel();

        //         sistema = sistemaModel.Incluir(pSistema);
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaController Incluir [" + ex.Message + "]");
        //     } finally {
        //         sistemaModel = null;
        //     }

        //     sistema.TratarLinks();

        //     if (sistema.Erro || !sistema.Validacao) {
        //         return BadRequest(sistema);
        //     } else {
        //         string uri = Url.Action("ConsultarPorId", new { id = sistema.Sistema.Id });

        //         return Created(uri, sistema);
        //     }
        // }

        // [HttpPut]
        // public IActionResult Alterar(SistemaTransfer pSistema)
        // {
        //     SistemaModel sistemaModel;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaModel = new SistemaModel();

        //         sistema = sistemaModel.Alterar(pSistema);
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaController Alterar [" + ex.Message + "]");
        //     } finally {
        //         sistemaModel = null;
        //     }

        //     sistema.TratarLinks();

        //     if (sistema.Erro || !sistema.Validacao) {
        //         return BadRequest(sistema);
        //     } else {
        //         return Ok(sistema);
        //     }
        // }

        // [HttpDelete("{id}")]
        // public IActionResult Excluir(int id)
        // {
        //     SistemaModel sistemaModel;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaModel = new SistemaModel();

        //         sistema = sistemaModel.Excluir(id);
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaController Excluir [" + ex.Message + "]");
        //     } finally {
        //         sistemaModel = null;
        //     }

        //     sistema.TratarLinks();

        //     if (sistema.Erro || !sistema.Validacao) {
        //         return BadRequest(sistema);
        //     } else {
        //         return Ok(sistema);
        //     }
        // }
    }
}
