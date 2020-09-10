using rcLogDatabase;
using rcLogTransfers;

namespace rcLogDatas
{
    public class SistemaData : Data
    {
        public SistemaData(LogDatabase db) : base(db)
        {
        }

        public void Incluir(SistemaTransfer pSistema)
        {
            LogComando cmd = db.Comando();

            cmd.Comando("");
            cmd.Tempo(1);
            cmd.IncluirParametro("", null, null, "");

            cmd.ExecutarComando();
        }
    }
}