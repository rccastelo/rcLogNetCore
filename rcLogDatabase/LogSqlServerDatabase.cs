using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace rcLogDatabase
{
    public class LogSqlServerDatabase : ILogDatabase
    {
        public int tempoConexao;
        private SqlConnection con = null;
        public SqlTransaction tran = null;

        public LogSqlServerDatabase()
        {
            this.tempoConexao = 5;

            AbrirConexao();
            IniciarTransacao();
        }

        private string ObterChaveConexao()
        {
            string chaveConexao = null;

            chaveConexao = Settings.GetConnectionString("sqlserver");

            return chaveConexao;
        }

        private void AbrirConexao()
        {
            this.con = new SqlConnection();
            this.con.ConnectionString = ObterChaveConexao();
            this.con.Open();
        }

        private void IniciarTransacao()
        {
            this.tran = this.con.BeginTransaction();
        }

        public LogComando Comando()
        {
            LogComando logCmd = new LogComando();

            logCmd.cmd = new LogSqlServerComando(this);

            return logCmd;
        }

        public void ConfirmarTransacao()
        {
            if (this.con.State == ConnectionState.Open)
            {
                if (this.tran != null)
                {
                    this.tran.Commit();
                }
            }

            FecharConexao();
        }

        public void CancelarTransacao()
        {
            if (this.con.State == ConnectionState.Open)
            {
                if (this.tran != null)
                {
                    this.tran.Rollback();
                }
            }

            FecharConexao();
        }

        private void FecharConexao()
        {
            if (this.con != null)
            {
                if (this.con.State == ConnectionState.Open)
                {
                    this.con.Close();
                }

                this.con.Dispose();
                this.con = null;
            }
        }
    }
}