using System;
using Microsoft.AspNetCore.Mvc;
using rcLogApiNetCore.Models;
using rcLogTransfers;

namespace rcLogApiNetCore.Controllers
{
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
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

            //logRetorno.TratarLinks();

            if (logRetorno.Erro || !logRetorno.Validacao) {
                return BadRequest(logRetorno);
            } else {
                return Ok(logRetorno);
            }
        }

        [HttpPost]
        public IActionResult Incluir(LogTransfer logDados)
        {
            LogModel logModel;
            LogTransfer logRetorno;

            try {
                logModel = new LogModel();

                logRetorno = logModel.Incluir(logDados);
            } catch (Exception ex) {
                logRetorno = new LogTransfer();

                logRetorno.Validacao = false;
                logRetorno.Erro = true;
                logRetorno.IncluirMensagem("Erro em LogController Incluir [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            // log.TratarLinks();

            if (logRetorno.Erro || !logRetorno.Validacao) {
                return BadRequest(logRetorno);
            } else {
                return Ok(logRetorno);
            }
        }
    }
}