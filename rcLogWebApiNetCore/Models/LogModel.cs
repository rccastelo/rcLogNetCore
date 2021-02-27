using System;
using rcLogDataModels;
using rcLogTransfers;

namespace rcLogWebApiNetCore.Models
{
    public class LogModel
    {
        // public LogTransfer Incluir(LogTransfer pLog)
        // {
        //     // LogDataModel logDataModel;
        //     LogTransfer logValidacao;
        //     LogTransfer logInclusao;

        //     try {
        //         // logBusiness = new LogBusiness();
        //         // logDataModel = new LogDataModel();

        //         // logValidacao = logBusiness.Validar(pLog);
        //         logValidacao = new LogTransfer();

        //         if (!logValidacao.Erro) {
        //             if (logValidacao.Validacao) {
        //                 // logInclusao = logDataModel.Incluir(logValidacao);
        //                 logInclusao = new LogTransfer();
        //             } else {
        //                 logInclusao = new LogTransfer(logValidacao);
        //             }
        //         } else {
        //             logInclusao = new LogTransfer(logValidacao);
        //         }
        //     } catch (Exception ex) {
        //         logInclusao = new LogTransfer();

        //         logInclusao.Validacao = false;
        //         logInclusao.Erro = true;
        //         logInclusao.IncluirMensagem("Erro em LogModel Incluir [" + ex.Message + "]");
        //     } finally {
        //         // logDataModel = null;
        //         // logBusiness = null;
        //         logValidacao = null;
        //     }

        //     return logInclusao;
        // }

        // public LogTransfer Alterar(LogTransfer pLog)
        // {
        //     // LogDataModel logDataModel;
        //     // LogBusiness logBusiness;
        //     LogTransfer logValidacao;
        //     LogTransfer logAlteracao;

        //     try {
        //         // logBusiness = new LogBusiness();
        //         // logDataModel = new LogDataModel();

        //         // logValidacao = logBusiness.Validar(pLog);
        //         logValidacao = new LogTransfer();

        //         if (!logValidacao.Erro) {
        //             if (logValidacao.Validacao) {
        //                 // logAlteracao = logDataModel.Alterar(logValidacao);
        //                 logAlteracao = new LogTransfer();
        //             } else {
        //                 logAlteracao = new LogTransfer(logValidacao);
        //             }
        //         } else {
        //             logAlteracao = new LogTransfer(logValidacao);
        //         }
        //     } catch (Exception ex) {
        //         logAlteracao = new LogTransfer();

        //         logAlteracao.Validacao = false;
        //         logAlteracao.Erro = true;
        //         logAlteracao.IncluirMensagem("Erro em LogModel Alterar [" + ex.Message + "]");
        //     } finally {
        //         // logDataModel = null;
        //         // logBusiness = null;
        //         logValidacao = null;
        //     }

        //     return logAlteracao;
        // }

        // public LogTransfer Excluir(int pId)
        // {
        //     // LogDataModel logDataModel;
        //     LogTransfer log;

        //     try {
        //         // logDataModel = new LogDataModel();

        //         // log = logDataModel.Excluir(pId);
        //         log = new LogTransfer();
        //     } catch (Exception ex) {
        //         log = new LogTransfer();

        //         log.Validacao = false;
        //         log.Erro = true;
        //         log.IncluirMensagem("Erro em LogModel Excluir [" + ex.Message + "]");
        //     } finally {
        //         // logDataModel = null;
        //     }

        //     return log;
        // }

        // public LogTransfer ConsultarPorId(int pId)
        // {
        //     // LogDataModel logDataModel;
        //     LogTransfer log;
            
        //     try {
        //         // logDataModel = new LogDataModel();

        //         // log = logDataModel.ConsultarPorId(pId);
        //         log = new LogTransfer();
        //     } catch (Exception ex) {
        //         log = new LogTransfer();

        //         log.Validacao = false;
        //         log.Erro = true;
        //         log.IncluirMensagem("Erro em LogModel ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         // logDataModel = null;
        //     }

        //     return log;
        // }

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