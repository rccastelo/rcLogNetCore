using System;
using rcLogTransfers;
using rcLogDatas;

namespace rcLogDataModels
{
    public class LogDataModel : DataModel
    {
        // public LogTransfer Incluir(LogTransfer logTransfer)
        // {
        //     LogData logData;
        //     LogTransfer cor;

        //     try {
        //         logData = new LogData(_contexto);
        //         cor = new LogTransfer(logTransfer);

        //         logData.Incluir(logTransfer.Cor);

        //         _contexto.SaveChanges();

        //         cor.Cor = new CorEntity(logTransfer.Cor);
        //         cor.Validacao = true;
        //         cor.Erro = false;
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogDataModel Incluir [" + ex.Message + "]");
        //     } finally {
        //         logData = null;
        //     }

        //     return cor;
        // }

        // public LogTransfer Alterar(LogTransfer logTransfer)
        // {
        //     LogData logData;
        //     LogTransfer cor;

        //     try {
        //         logData = new LogData(_contexto);
        //         cor = new LogTransfer();

        //         logData.Alterar(logTransfer.Cor);

        //         _contexto.SaveChanges();

        //         cor.Cor = new CorEntity(logTransfer.Cor);
        //         cor.Validacao = true;
        //         cor.Erro = false;
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogDataModel Alterar [" + ex.Message + "]");
        //     } finally {
        //         logData = null;
        //     }

        //     return cor;
        // }

        // public LogTransfer Excluir(int id)
        // {
        //     LogData logData;
        //     LogTransfer cor;

        //     try {
        //         logData = new LogData(_contexto);
        //         cor = new LogTransfer();

        //         cor.Cor = logData.ConsultarPorId(id);
        //         logData.Excluir(cor.Cor);

        //         _contexto.SaveChanges();

        //         cor.Validacao = true;
        //         cor.Erro = false;
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogDataModel Excluir [" + ex.Message + "]");
        //     } finally {
        //         logData = null;
        //     }

        //     return cor;
        // }

        // public LogTransfer ConsultarPorId(int id)
        // {
        //     LogData logData;
        //     LogTransfer cor;

        //     try {
        //         logData = new LogData(_contexto);
        //         cor = new LogTransfer();

        //         cor.Cor = logData.ConsultarPorId(id);
        //         cor.Validacao = true;
        //         cor.Erro = false;
        //     } catch (Exception ex) {
        //         cor = new LogTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogDataModel ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         logData = null;
        //     }

        //     return cor;
        // }

        public LogTransfer Listar(LogTransfer logDados)
        {
            LogData logData;
            LogTransfer logRetorno;

            try {
                logData = new LogData(db);

                logRetorno = logData.Listar(logDados);

                db.ConfirmarTransacao();
            } catch (Exception ex) {
                logRetorno = new LogTransfer();

                logRetorno.Validacao = false;
                logRetorno.Erro = true;
                logRetorno.IncluirMensagem("Erro em LogDataModel Consultar [" + ex.Message + "]");
            } finally {
                logData = null;
            }

            return logRetorno;
        }
    }
}
