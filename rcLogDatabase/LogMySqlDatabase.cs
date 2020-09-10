using System.Data;
using MySql.Data.MySqlClient;

namespace rcLogDatabase
{
    public class LogMySqlDatabase : ILogDatabase
    {
        public int tempoConexao;
        private MySqlConnection con = null;
        public MySqlTransaction tran = null;

        public LogMySqlDatabase()
        {
            this.tempoConexao = 5;

            AbrirConexao();
            IniciarTransacao();
        }

        private string ObterChaveConexao()
        {
            string chaveConexao = null;

            chaveConexao = Settings.GetConnectionString("mysql");

            return chaveConexao;
        }

        private void AbrirConexao()
        {
            this.con = new MySqlConnection();
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

            logCmd.cmd = new LogMySqlComando(this);

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