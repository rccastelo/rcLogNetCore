using System;
using rcLogDataModels;
using rcLogTransfers;

namespace rcLogWebApiNetCore.Models
{
    public class LogModel
    {
        public LogTransfer Incluir(LogTransfer logDados)
        {
            LogDataModel logDataModel;
            LogTransfer logValidacao;
            LogTransfer logRetorno;

            try {
                // logBusiness = new LogBusiness();
                logDataModel = new LogDataModel();

                // logValidacao = logBusiness.Validar(pLog);
                logValidacao = new LogTransfer(logDados);

                if (!logValidacao.Erro) {
                    if (logValidacao.Validacao) {
                        logRetorno = logDataModel.Incluir(logValidacao);
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
                logRetorno.IncluirMensagem("Erro em LogModel Incluir [" + ex.Message + "]");
            } finally {
                logDataModel = null;
                // logBusiness = null;
                logValidacao = null;
            }

            return logRetorno;
        }
    }
}