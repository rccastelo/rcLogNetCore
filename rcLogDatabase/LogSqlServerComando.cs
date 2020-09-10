using System.Data;
using System.Data.SqlClient;

namespace rcLogDatabase
{
    public class LogSqlServerComando : ILogComando
    {
        public SqlCommand cmd = null;
        public LogSqlServerDatabase db = null;

        public LogSqlServerComando(LogSqlServerDatabase dbSqlServer)
        {
            this.db = dbSqlServer;

            CriarComando();
            IncluirTransacao();
        }

        private void CriarComando() 
        {
            this.cmd = new SqlCommand();
            this.cmd.CommandTimeout = db.tempoConexao;
        }

        private void IncluirTransacao()
        {
            this.cmd.Transaction = db.tran;
        }

        public void IncluirParametro(string pNome, DbType pTipo, int? pTamanho, object pValor)
        {
            SqlParameter param = this.cmd.CreateParameter();
            
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