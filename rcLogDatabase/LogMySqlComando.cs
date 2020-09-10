using System.Data;
using MySql.Data.MySqlClient;

namespace rcLogDatabase
{
    public class LogMySqlComando : ILogComando
    {
        public MySqlCommand cmd = null;
        public LogMySqlDatabase db = null;

        public LogMySqlComando(LogMySqlDatabase dbMySql)
        {
            this.db = dbMySql;

            CriarComando();
            IncluirTransacao();
        }

        private void CriarComando() 
        {
            this.cmd = new MySqlCommand();
            this.cmd.CommandTimeout = db.tempoConexao;
        }

        private void IncluirTransacao()
        {
            this.cmd.Transaction = db.tran;
        }

        public void IncluirParametro(string pNome, DbType pTipo, int? pTamanho, object pValor)
        {
            MySqlParameter param = this.cmd.CreateParameter();

            param.ParameterName = pNome;
            param.DbType = pTipo;
            if (pTamanho.HasValue)
                param.Size = (int)pTamanho;
            param.Value = pValor;

            this.cmd.Parameters.Add(param);
        }

        public void ExcluirParametros()
        {
            this.cmd.Parameters.Clear();
        }

        public void Comando(string pComando)
        {
            this.cmd.CommandText = pComando;
        }

        public void Tempo(int pTempoConexao)
        {
            this.cmd.CommandTimeout = pTempoConexao;
        }

        public int? ExecutarComando()
        {
            throw new System.NotImplementedException();
        }
    }
}