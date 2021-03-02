using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcLogTransfers;
using rcLogWebNetCore.Services;

namespace rcLogWebNetCore.Models
{
    public class LogModel
    {
        // private readonly IHttpContextAccessor httpContext;

        // public LogModel(IHttpContextAccessor pAccessor)
        // {
        //     httpContext = pAccessor;
        // }

        // public async Task<LogTransfer> Incluir(LogTransfer logTransfer)
        // {
        //     LogService logService;
        //     LogTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;

        //     try {
        //         logService = new LogService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await logService.Incluir(logTransfer, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel Incluir [" + ex.Message + "]");
        //     } finally {
        //         logService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        // public async Task<LogTransfer> Alterar(LogTransfer logTransfer)
        // {
        //     LogService logService;
        //     LogTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;

        //     try {
        //         logService = new LogService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await logService.Alterar(logTransfer, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel Alterar [" + ex.Message + "]");
        //     } finally {
        //         logService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        // public async Task<LogTransfer> Excluir(int pId)
        // {
        //     LogService logService;
        //     LogTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;

        //     try {
        //         logService = new LogService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await logService.Excluir(pId, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel Excluir [" + ex.Message + "]");
        //     } finally {
        //         logService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        // public async Task<LogTransfer> ConsultarPorId(int pId)
        // {
        //     LogService logService;
        //     LogTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;
            
        //     try {
        //         logService = new LogService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await logService.ConsultarPorId(pId, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         logService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        // public async Task<LogTransfer> Consultar(LogTransfer pLogLista)
        // {
        //     LogService logService;
        //     LogTransfer logLista;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;
        //     int dif = 0;
        //     int qtdExibe = 5;

        //     try {
        //         logService = new LogService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         logLista = await logService.Listar(pLogLista, autorizacao);

        //         if (logLista != null) {
        //             if (logLista.Paginacao.TotalRegistros > 0) {
        //                 if (logLista.Paginacao.RegistrosPorPagina < 1) {
        //                     logLista.Paginacao.RegistrosPorPagina = 30;
        //                 } else if (logLista.Paginacao.RegistrosPorPagina > 200) {
        //                     logLista.Paginacao.RegistrosPorPagina = 30;
        //                 }

        //                 logLista.Paginacao.PaginaAtual = (logLista.Paginacao.PaginaAtual < 1 ? 1 : logLista.Paginacao.PaginaAtual);
        //                 logLista.Paginacao.TotalPaginas = 
        //                     Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(logLista.Paginacao.TotalRegistros) 
        //                     / @Convert.ToDecimal(logLista.Paginacao.RegistrosPorPagina)));
        //                 logLista.Paginacao.TotalPaginas = (logLista.Paginacao.TotalPaginas < 1 ? 1 : logLista.Paginacao.TotalPaginas);
        //                 if (logLista.Paginacao.PaginaAtual > logLista.Paginacao.TotalPaginas) {
        //                     logLista.Paginacao.PaginaAtual = logLista.Paginacao.TotalPaginas;
        //                 }

        //                 qtdExibe = (qtdExibe > logLista.Paginacao.TotalPaginas ? logLista.Paginacao.TotalPaginas : qtdExibe);

        //                 logLista.Paginacao.PaginaInicial = logLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
        //                 logLista.Paginacao.PaginaFinal = logLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
        //                 logLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (logLista.Paginacao.PaginaFinal - 1) : logLista.Paginacao.PaginaFinal);

        //                 if (logLista.Paginacao.PaginaInicial < 1) {
        //                     dif = 1 - logLista.Paginacao.PaginaInicial;
        //                     logLista.Paginacao.PaginaInicial += dif;
        //                     logLista.Paginacao.PaginaFinal += dif;
        //                 }

        //                 if (logLista.Paginacao.PaginaFinal > logLista.Paginacao.TotalPaginas) {
        //                     dif = logLista.Paginacao.PaginaFinal - logLista.Paginacao.TotalPaginas;
        //                     logLista.Paginacao.PaginaInicial -= dif;
        //                     logLista.Paginacao.PaginaFinal -= dif;
        //                 }

        //                 logLista.Paginacao.PaginaInicial = (logLista.Paginacao.PaginaInicial < 1 ? 1 : logLista.Paginacao.PaginaInicial);
        //                 logLista.Paginacao.PaginaFinal = (logLista.Paginacao.PaginaFinal > logLista.Paginacao.TotalPaginas ? 
        //                     logLista.Paginacao.TotalPaginas : logLista.Paginacao.PaginaFinal);
        //             }
        //         }
        //     } catch (Exception ex) {
        //         logLista = new LogTransfer();

        //         logLista.Validacao = false;
        //         logLista.Erro = true;
        //         logLista.IncluirMensagem("Erro em LogModel Consultar [" + ex.Message + "]");
        //     } finally {
        //         logService = null;
        //         autenticaModel = null;
        //     }

        //     return logLista;
        // }
    }
}
