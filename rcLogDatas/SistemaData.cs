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

            cmd.Comando("SELECT * FROM Sistema");
            //cmd.IncluirParametro("", null, null, "");

            dr = cmd.ExecutarComandoLista();

            if (dr != null) {
                ret =  new SistemaTransfer();

                if (dr.HasRows) {
                    while(dr.Read()) {
                        SistemaEntity sistema = new SistemaEntity();

                        ret.IncluirSistema(sistema);
                    }
                }
            }

            dr.Dispose();

            return ret;
        }
    }
}