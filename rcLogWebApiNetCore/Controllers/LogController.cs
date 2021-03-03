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