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
            LogComando cmd = db.Comando();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            if (pSistema.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (pSistema.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = pSistema.Paginacao.RegistrosPorPagina;
            }

            pular = (pSistema.Paginacao.PaginaAtual < 2 ? 0 : pSistema.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;

            string comandoSql = $"SELECT s.*, qq.qtd AS qtd_query " +
                "FROM Sistema s " +
                "CROSS JOIN (SELECT Count(*) AS qtd FROM Sistema) AS qq " +
                "ORDER BY s.id " +
                "OFFSET " + pular + " ROWS " +
                "FETCH NEXT " + registrosPorPagina + " ROWS ONLY";

            cmd.Comando(comandoSql);
            //cmd.IncluirParametro("", null, null, "");

            dr = cmd.ExecutarComandoLista();

            if (dr != null) {
                ret =  new SistemaTransfer();

                if (dr.HasRows) {
                    while(dr.Read()) {
                        SistemaEntity sistema = new SistemaEntity();

                        sistema.Id = Convert.ToInt32(dr["id"]);
                        sistema.Nome = Convert.ToString(dr["nome"]);
                        sistema.Descricao = Convert.ToString(dr["descricao"]);
                        sistema.Codigo = Convert.ToString(dr["codigo"]);
                        sistema.Ativo = Convert.ToBoolean(dr["ativo"]);
                        
                        totalRegistros = Convert.ToInt32(dr["qtd_query"]);

                        ret.IncluirSistema(sistema);
                    }

                    ret.Paginacao.RegistrosPorPagina = registrosPorPagina;
                    ret.Paginacao.TotalRegistros = totalRegistros;
                }
            }

            dr.Dispose();

            return ret;
        }
    }
}