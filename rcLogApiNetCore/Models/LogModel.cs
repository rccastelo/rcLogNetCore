using System;
using rcLogDataModels;
using rcLogTransfers;

namespace rcLogApiNetCore.Models
{
    public class LogModel
    {
        public LogTransfer Listar(LogTransfer logDados)
        {
            LogDataModel logDataModel;
            LogTransfer logValidacao;
            LogTransfer logRetorno;

            try {
                logDataModel = new LogDataModel();

                logValidacao = new LogTransfer(logDados);

                if (!logValidacao.Erro) {
                    if (logValidacao.Validacao) {
                        logRetorno = logDataModel.Listar(logValidacao);

                        if (logRetorno != null) {
                            if (logRetorno.Paginacao.TotalRegistros > 0) {
                                if (logRetorno.Paginacao.RegistrosPorPagina < 1) {
                                    logRetorno.Paginacao.RegistrosPorPagina = 30;
                                } else if (logRetorno.Paginacao.RegistrosPorPagina > 200) {
                                    logRetorno.Paginacao.RegistrosPorPagina = 30;
                                }
                                logRetorno.Paginacao.PaginaAtual = (logDados.Paginacao.PaginaAtual < 1 ? 1 : logDados.Paginacao.PaginaAtual);
                                logRetorno.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(logRetorno.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(logRetorno.Paginacao.RegistrosPorPagina)));
                                if (logRetorno.Paginacao.PaginaAtual > logRetorno.Paginacao.TotalPaginas) {
                                    logRetorno.Paginacao.PaginaAtual = logRetorno.Paginacao.TotalPaginas;
                                }
                            }
                        }
                    } else {
                        logRetorno = new LogTransfer(logValidacao);
                    }
                } else {
                    logRetorno = new LogTransfer(logValidacao);
                }
            } catch (Exception ex) {
                logRetorno = new LogTransfer();

                logRetorno.Validacao = false;
                logRetorno.Erro = true;
                logRetorno.IncluirMensagem("Erro em LogModel Consultar [" + ex.Message + "]");
            } finally {
                logDataModel = null;
                logValidacao = null;
            }

            return logRetorno;
        }        
    }
}