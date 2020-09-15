using System;
using rcLogDataModels;
using rcLogTransfers;

namespace rcLogWebApi.Models
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

        public LogTransfer Consultar(LogTransfer pLogLista)
        {
            LogDataModel logDataModel;
            // LogBusiness logBusiness;
            LogTransfer logValidacao;
            LogTransfer logLista;

            try {
                // logBusiness = new LogBusiness();
                logDataModel = new LogDataModel();

                // logValidacao = logBusiness.ValidarConsulta(pLogLista);
                logValidacao = new LogTransfer(pLogLista);

                if (!logValidacao.Erro) {
                    if (logValidacao.Validacao) {
                        logLista = logDataModel.Consultar(logValidacao);

                        if (logLista != null) {
                            if (logLista.Paginacao.TotalRegistros > 0) {
                                if (logLista.Paginacao.RegistrosPorPagina < 1) {
                                    logLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (logLista.Paginacao.RegistrosPorPagina > 200) {
                                    logLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                logLista.Paginacao.PaginaAtual = (pLogLista.Paginacao.PaginaAtual < 1 ? 1 : pLogLista.Paginacao.PaginaAtual);
                                logLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(logLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(logLista.Paginacao.RegistrosPorPagina)));
                                if (logLista.Paginacao.PaginaAtual > logLista.Paginacao.TotalPaginas) {
                                    logLista.Paginacao.PaginaAtual = logLista.Paginacao.TotalPaginas;
                                }
                            }
                        }
                    } else {
                        logLista = new LogTransfer(logValidacao);
                    }
                } else {
                    logLista = new LogTransfer(logValidacao);
                }
            } catch (Exception ex) {
                logLista = new LogTransfer();

                logLista.Validacao = false;
                logLista.Erro = true;
                logLista.IncluirMensagem("Erro em LogModel Consultar [" + ex.Message + "]");
            } finally {
                logDataModel = null;
                // logBusiness = null;
                logValidacao = null;
            }

            return logLista;
        }
    }
}
