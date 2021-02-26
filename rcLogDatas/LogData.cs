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
                        LogEntity log = new LogEntity();

                        log.Sistema = Conversao.RetornarString(dr["sistema"]);
                        log.Data = Conversao.RetornarInt32(dr["data"]);
                        log.Hora = Conversao.RetornarInt32(dr["hora"]);
                        log.Controle = Conversao.RetornarString(dr["controle"]);
                        log.Ip = Conversao.RetornarString(dr["ip"]);
                        log.Tipo = Conversao.RetornarInt32(dr["tipo"]);
                        log.Mensagem = Conversao.RetornarString(dr["mensagem"]);
                        log.Pilha = Conversao.RetornarString(dr["pilha"]);
                        log.Origem = Conversao.RetornarString(dr["origem"]);
                        log.Critico = Conversao.RetornarBoolean(dr["critico"]);
                        
                        totalRegistros = Conversao.RetornarInt32(dr["qtd_query"]);

                        ret.IncluirLog(log);
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