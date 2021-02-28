using System;
using Microsoft.AspNetCore.Mvc;
using rcLogTransfers;
using rcLogWebApiNetCore.Models;

namespace rcLogWebApiNetCore.Controllers
{
    // [Authorize]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        // [HttpGet("{id}")]
        // public IActionResult ConsultarPorId(int pId)
        // {
        //     LogModel logModel;
        //     LogTransfer log;

        //     try {
        //         logModel = new LogModel();

        //         if (pId > 0) {
        //             log = logModel.ConsultarPorId(pId);
        //         } else {
        //             log = null;
        //         }
        //     } catch (Exception ex) {
        //         log = new LogTransfer();
                
        //         log.Validacao = false;
        //         log.Erro = true;
        //         log.IncluirMensagem("Erro em LogController ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         logModel = null;
        //     }

        //     log.TratarLinks();

        //     if (log.Erro || !log.Validacao) {
        //         return BadRequest(log);
        //     } else {
        //         return Ok(log);
        //     }
        // }

        // [HttpGet]
        // public IActionResult Listar()
        // {
        //     LogModel logModel;
        //     LogTransfer logLista;

        //     try {
        //         logModel = new LogModel();

        //         logLista = logModel.Consultar(new LogTransfer());
        //     } catch (Exception ex) {
        //         logLista = new LogTransfer();

        //         logLista.Validacao = false;
        //         logLista.Erro = true;
        //         logLista.IncluirMensagem("Erro em LogController Listar [" + ex.Message + "]");
        //     } finally {
        //         logModel = null;
        //     }

        //     logLista.TratarLinks();

        //     if (logLista.Erro || !logLista.Validacao) {
        //         return BadRequest(logLista);
        //     } else {
        //         return Ok(logLista);
        //     }
        // }

        [HttpPost("Listar")]
        public IActionResult Listar([FromBody] LogTransfer logDados)
        {
            LogModel logModel;
            LogTransfer logRetorno;

            try {
                logModel = new LogModel();

                logRetorno = logModel.Listar(logDados);
            } catch (Exception ex) {
                logRetorno = new LogTransfer();

                logRetorno.Erro = true;
                logRetorno.IncluirMensagem("Erro em LogController Consultar [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            logRetorno.TratarLinks();

            if (logRetorno.Erro || !logRetorno.Validacao) {
                return BadRequest(logRetorno);
            } else {
                return Ok(logRetorno);
            }
        }

        // [HttpPost]
        // public IActionResult Incluir(LogTransfer pLog)
        // {
        //     LogModel logModel;
        //     LogTransfer log;

        //     try {
        //         logModel = new LogModel();

        //         log = logModel.Incluir(pLog);
        //     } catch (Exception ex) {
        //         log = new LogTransfer();

        //         log.Validacao = false;
        //         log.Erro = true;
        //         log.IncluirMensagem("Erro em LogController Incluir [" + ex.Message + "]");
        //     } finally {
        //         logModel = null;
        //     }

        //     log.TratarLinks();

        //     if (log.Erro || !log.Validacao) {
        //         return BadRequest(log);
        //     } else {
        //         string uri = Url.Action("ConsultarPorId", new { id = log.Log.Id });

        //         return Created(uri, log);
        //     }
        // }

        // [HttpPut]
        // public IActionResult Alterar(LogTransfer pLog)
        // {
        //     LogModel logModel;
        //     LogTransfer log;

        //     try {
        //         logModel = new LogModel();

        //         log = logModel.Alterar(pLog);
        //     } catch (Exception ex) {
        //         log = new LogTransfer();

        //         log.Validacao = false;
        //         log.Erro = true;
        //         log.IncluirMensagem("Erro em LogController Alterar [" + ex.Message + "]");
        //     } finally {
        //         logModel = null;
        //     }

        //     log.TratarLinks();

        //     if (log.Erro || !log.Validacao) {
        //         return BadRequest(log);
        //     } else {
        //         return Ok(log);
        //     }
        // }

        // [HttpDelete("{id}")]
        // public IActionResult Excluir(int pId)
        // {
        //     LogModel logModel;
        //     LogTransfer log;

        //     try {
        //         logModel = new LogModel();

        //         log = logModel.Excluir(pId);
        //     } catch (Exception ex) {
        //         log = new LogTransfer();

        //         log.Validacao = false;
        //         log.Erro = true;
        //         log.IncluirMensagem("Erro em LogController Excluir [" + ex.Message + "]");
        //     } finally {
        //         logModel = null;
        //     }

        //     log.TratarLinks();

        //     if (log.Erro || !log.Validacao) {
        //         return BadRequest(log);
        //     } else {
        //         return Ok(log);
        //     }
        // }
    }
}