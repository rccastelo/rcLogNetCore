using System;
using System.Data.Common;
using rcLogDatabase;
using rcLogEntities;
using rcLogTransfers;

namespace rcLogDatas
{
    public class SistemaData : Data
    {
        public SistemaData(LogDatabase pDB) : base(pDB)
        {
        }

        public SistemaTransfer Consultar(SistemaTransfer pSistema)
        {
            DbDataReader dr = null;
            SistemaTransfer ret = null;

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            LogComando cmd = db.Comando();

            cmd.Comando("SELECT * FROM Sistema");
            //cmd.IncluirParametro("", null, null, "");

            dr = cmd.ExecutarComandoLista();

            if (dr != null) {
                ret =  new SistemaTransfer();

                if (dr.HasRows) {

                    if (pSistema.Paginacao.RegistrosPorPagina < 1) {
                        registrosPorPagina = 30;
                    } else if (pSistema.Paginacao.RegistrosPorPagina > 200) {
                        registrosPorPagina = 30;
                    } else {
                        registrosPorPagina = pSistema.Paginacao.RegistrosPorPagina;
                    }

                    pular = (pSistema.Paginacao.PaginaAtual < 2 ? 0 : pSistema.Paginacao.PaginaAtual - 1);
                    pular *= registrosPorPagina;

                    while(dr.Read()) {
                        SistemaEntity sistema = new SistemaEntity();

                        sistema.Id = Convert.ToInt32(dr["id"]);
                        sistema.Nome = Convert.ToString(dr["nome"]);
                        sistema.Descricao = Convert.ToString(dr["descricao"]);
                        sistema.Codigo = Convert.ToString(dr["codigo"]);
                        sistema.Ativo = Convert.ToBoolean(dr["ativo"]);

                        ret.IncluirSistema(sistema);
                    }

                    totalRegistros = ret.Lista.Count;

                    ret.Paginacao.RegistrosPorPagina = registrosPorPagina;
                    ret.Paginacao.TotalRegistros = totalRegistros;
                }
            }

            dr.Dispose();

            return ret;
        }
    }
}