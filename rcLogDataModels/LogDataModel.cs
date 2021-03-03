using System;
using rcLogDatas;
using rcLogTransfers;

namespace rcLogDataModels
{
    public class LogDataModel : DataModel
    {
        public LogTransfer Listar(LogTransfer logDados)
        {
            LogData logData;
            LogTransfer logRetorno;

            try {
                logData = new LogData(db);

                logRetorno = logData.Listar(logDados);

                db.ConfirmarTransacao();
            } catch (Exception ex) {
                db.CancelarTransacao();
                
                logRetorno = new LogTransfer();
                logRetorno.Erro = true;
                logRetorno.IncluirMensagem("Erro em LogDataModel Consultar [" + ex.Message + "]");
            } finally {
                logData = null;
            }

            return logRetorno;
        }

        public LogTransfer Incluir(LogTransfer logDados)
        {
            LogData logData;
            LogTransfer logRetorno;

            try {
                logData = new LogData(db);

                logRetorno = logData.Incluir(logDados);

                db.ConfirmarTransacao();
            } catch (Exception ex) {
                db.CancelarTransacao();

                logRetorno = new LogTransfer();
                logRetorno.Erro = true;
                logRetorno.IncluirMensagem("Erro em LogDataModel Incluir [" + ex.Message + "]");
            } finally {
                logData = null;
            }

            return logRetorno;
        }
    }
}