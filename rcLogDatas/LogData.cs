using System;
using System.Data.Common;
using rcLogDatabase;
using rcLogEntities;
using rcLogTransfers;
using rcLogUtils;

namespace rcLogDatas
{
    public class LogData : Data
    {
        public LogData(LogDatabase pDB) : base(pDB)
        {
        }

        public LogTransfer Consultar(LogTransfer pLog)
        {
            DbDataReader dr = null;
            LogTransfer ret = null;
            LogComando cmd = db.Comando();

            int pular = 0;
            int registrosPorPagina = 0;
            int totalRegistros = 0;

            if (pLog.Paginacao.RegistrosPorPagina < 1) {
                registrosPorPagina = 30;
            } else if (pLog.Paginacao.RegistrosPorPagina > 200) {
                registrosPorPagina = 30;
            } else {
                registrosPorPagina = pLog.Paginacao.RegistrosPorPagina;
            }

            pular = (pLog.Paginacao.PaginaAtual < 2 ? 0 : pLog.Paginacao.PaginaAtual - 1);
            pular *= registrosPorPagina;

            string sqlSelect = $"SELECT l.*, qq.qtd AS qtd_query FROM Log l ";
            string sqlWhere = "";
            string sqlJoin = "CROSS JOIN (";
            string sqlSelectJoin = "SELECT Count(*) AS qtd FROM Log ";
            string sqlOrder = ") AS qq ORDER BY l.id ";
            string sqlPaginacao = "OFFSET " + pular + " ROWS FETCH NEXT " + registrosPorPagina + " ROWS ONLY";

            string sqlComando = sqlSelect + sqlWhere + sqlJoin + sqlSelectJoin + sqlWhere + sqlOrder + sqlPaginacao;

            cmd.Comando(sqlComando);

            dr = cmd.ExecutarComandoLista();

            if (dr != null) {
                ret =  new LogTransfer();

                if (dr.HasRows) {
                    while(dr.Read()) {
                        LogEntity sistema = new LogEntity();

                        sistema.Id = Conversao.RetornarInt32(dr["id"]);
                        sistema.Data = Conversao.RetornarInt32(dr["data"]);
                        sistema.Hora = Conversao.RetornarInt32(dr["hora"]);
                        sistema.Sistema = Conversao.RetornarInt32(dr["sistema"]);
                        sistema.Tipo = Conversao.RetornarInt32(dr["tipo"]);
                        sistema.Descricao = Conversao.RetornarString(dr["descricao"]);
                        sistema.Mensagem = Conversao.RetornarString(dr["mensagem"]);
                        
                        totalRegistros = Conversao.RetornarInt32(dr["qtd_query"]);

                        ret.IncluirLog(sistema);
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