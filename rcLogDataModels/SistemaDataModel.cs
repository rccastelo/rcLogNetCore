using System;
using rcLogDatas;
using rcLogTransfers;

namespace rcLogDataModels
{
    public class SistemaDataModel : DataModel
    {
        // public SistemaTransfer Incluir(SistemaTransfer pSistema)
        // {
        //     SistemaData sistemaData;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaData = new SistemaData(db);
        //         sistema = new SistemaTransfer(pSistema);

        //         sistemaData.Incluir(sistema);

        //         db.ConfirmarTransacao();
        //     } catch (Exception ex) {
        //         db.CancelarTransacao();
                
        //         sistema = new SistemaTransfer();

        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaDataModel Incluir [" + ex.Message + "]");
        //     } finally {
        //         sistemaData = null;
        //     }

        //     return sistema;
        // }

        // public SistemaTransfer Alterar(SistemaTransfer pSistema)
        // {
        //     SistemaData sistemaData;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaData = new SistemaData(_contexto);
        //         sistema = new SistemaTransfer();

        //         sistemaData.Alterar(pSistema.Cor);

        //         _contexto.SaveChanges();

        //         sistema.Cor = new CorEntity(pSistema.Cor);
        //         sistema.Validacao = true;
        //         sistema.Erro = false;
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaDataModel Alterar [" + ex.Message + "]");
        //     } finally {
        //         sistemaData = null;
        //     }

        //     return sistema;
        // }

        // public SistemaTransfer Excluir(int id)
        // {
        //     SistemaData sistemaData;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaData = new SistemaData(_contexto);
        //         sistema = new SistemaTransfer();

        //         sistema.Cor = sistemaData.ConsultarPorId(id);
        //         sistemaData.Excluir(sistema.Cor);

        //         _contexto.SaveChanges();

        //         sistema.Validacao = true;
        //         sistema.Erro = false;
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaDataModel Excluir [" + ex.Message + "]");
        //     } finally {
        //         sistemaData = null;
        //     }

        //     return sistema;
        // }

        // public SistemaTransfer ConsultarPorId(int id)
        // {
        //     SistemaData sistemaData;
        //     SistemaTransfer sistema;

        //     try {
        //         sistemaData = new SistemaData(_contexto);
        //         sistema = new SistemaTransfer();

        //         sistema.Cor = sistemaData.ConsultarPorId(id);
        //         sistema.Validacao = true;
        //         sistema.Erro = false;
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaDataModel ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         sistemaData = null;
        //     }

        //     return sistema;
        // }

        public SistemaTransfer Consultar(SistemaTransfer pSistema)
        {
            SistemaData sistemaData;
            SistemaTransfer ret;

            try {
                sistemaData = new SistemaData(db);

                ret = sistemaData.Consultar(pSistema);

                db.ConfirmarTransacao();
            } catch (Exception ex) {
                ret = new SistemaTransfer();

                ret.Erro = true;

                ret.IncluirMensagem("Erro em SistemaDataModel Consultar [" + ex.Message + "]");
            } finally {
                sistemaData = null;
            }

            return ret;
        }
    }
}
