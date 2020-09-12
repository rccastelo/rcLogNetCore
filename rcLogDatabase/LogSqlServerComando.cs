using System.Data;
using System.Data.Common;
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
            this.cmd.Connection = db.con;
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
            int? retorno;

            this.cmd.CommandType = CommandType.Text;

            retorno = this.cmd.ExecuteNonQuery();

            return retorno;
        }

        public object ExecutarComandoObjeto()
        {
            object retorno;

            this.cmd.CommandType = CommandType.Text;

            retorno = this.cmd.ExecuteScalar();

            return retorno;
        }

        public DbDataReader ExecutarComandoLista()
        {
            SqlDataReader retorno;

            this.cmd.CommandType = CommandType.Text;

            retorno = this.cmd.ExecuteReader();

            return retorno;
        }

        public int? ExecutarProcedimento()
        {
            int? retorno = null;

            this.cmd.CommandType = CommandType.StoredProcedure;

            retorno = this.cmd.ExecuteNonQuery();

            return retorno;
        }

        public object ExecutarProcedimentoObjeto()
        {
            object retorno = null;

            this.cmd.CommandType = CommandType.StoredProcedure;

            retorno = this.cmd.ExecuteScalar();

            return retorno;
        }

        public DbDataReader ExecutarProcedimentoLista()
        {
            SqlDataReader retorno = null;

            this.cmd.CommandType = CommandType.StoredProcedure;

            retorno = this.cmd.ExecuteReader();

            return retorno;
        }
    }
}