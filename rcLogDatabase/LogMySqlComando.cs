using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace rcLogDatabase
{
    public class LogMySqlComando : ILogComando
    {
        public MySqlCommand cmd = null;
        public LogMySqlDatabase db = null;

        public LogMySqlComando(LogMySqlDatabase pDB)
        {
            this.db = pDB;

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
            MySqlDataReader retorno;

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
            MySqlDataReader retorno = null;

            this.cmd.CommandType = CommandType.StoredProcedure;

            retorno = this.cmd.ExecuteReader();

            return retorno;
        }
    }
}