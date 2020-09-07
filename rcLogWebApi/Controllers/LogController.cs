using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcLogWebApi.Models;
using rcLogTransfers;

namespace rcLogWebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            LogModel logModel;
            LogTransfer log;

            try {
                logModel = new LogModel();

                if (id > 0) {
                    log = logModel.ConsultarPorId(id);
                } else {
                    log = null;
                }
            } catch (Exception ex) {
                log = new LogTransfer();
                
                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogController ConsultarPorId [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            log.TratarLinks();

            if (log.Erro || !log.Validacao) {
                return BadRequest(log);
            } else {
                return Ok(log);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            LogModel logModel;
            LogTransfer logLista;

            try {
                logModel = new LogModel();

                logLista = logModel.Consultar(new LogTransfer());
            } catch (Exception ex) {
                logLista = new LogTransfer();

                logLista.Validacao = false;
                logLista.Erro = true;
                logLista.IncluirMensagem("Erro em LogController Listar [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            logLista.TratarLinks();

            if (logLista.Erro || !logLista.Validacao) {
                return BadRequest(logLista);
            } else {
                return Ok(logLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(LogTransfer sistemaTransfer)
        {
            LogModel logModel;
            LogTransfer logLista;

            try {
                logModel = new LogModel();

                logLista = logModel.Consultar(sistemaTransfer);
            } catch (Exception ex) {
                logLista = new LogTransfer();

                logLista.Validacao = false;
                logLista.Erro = true;
                logLista.IncluirMensagem("Erro em LogController Consultar [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            logLista.TratarLinks();

            if (logLista.Erro || !logLista.Validacao) {
                return BadRequest(logLista);
            } else {
                return Ok(logLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(LogTransfer sistemaTransfer)
        {
            LogModel logModel;
            LogTransfer log;

            try {
                logModel = new LogModel();

                log = logModel.Incluir(sistemaTransfer);
            } catch (Exception ex) {
                log = new LogTransfer();

                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogController Incluir [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            log.TratarLinks();

            if (log.Erro || !log.Validacao) {
                return BadRequest(log);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = log.Log.Id });

                return Created(uri, log);
            }
        }

        [HttpPut]
        public IActionResult Alterar(LogTransfer sistemaTransfer)
        {
            LogModel logModel;
            LogTransfer log;

            try {
                logModel = new LogModel();

                log = logModel.Alterar(sistemaTransfer);
            } catch (Exception ex) {
                log = new LogTransfer();

                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogController Alterar [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            log.TratarLinks();

            if (log.Erro || !log.Validacao) {
                return BadRequest(log);
            } else {
                return Ok(log);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            LogModel logModel;
            LogTransfer log;

            try {
                logModel = new LogModel();

                log = logModel.Excluir(id);
            } catch (Exception ex) {
                log = new LogTransfer();

                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogController Excluir [" + ex.Message + "]");
            } finally {
                logModel = null;
            }

            log.TratarLinks();

            if (log.Erro || !log.Validacao) {
                return BadRequest(log);
            } else {
                return Ok(log);
            }
        }
    }
}
