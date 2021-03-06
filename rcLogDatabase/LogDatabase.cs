using System.Data.Common;

namespace rcLogDatabase
{
    public class LogDatabase
    {
        private ILogDatabase db;

        public LogDatabase() {
            string dbTipo = Settings.GetSetting("dbTipo");

            this.db = LogDatabaseFactory.Selecionar(dbTipo);
        }

        public void ConfirmarTransacao() {
            this.db.ConfirmarTransacao();
        }

        public void CancelarTransacao() {
            this.db.CancelarTransacao();
        }

        public LogComando Comando() {
            return db.Comando();
        }
    }
}