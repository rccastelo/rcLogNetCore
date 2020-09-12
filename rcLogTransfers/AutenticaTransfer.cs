namespace rcLogTransfers
{
  public class AutenticaTransfer : Transfer
    {
        public string Apelido { get; set; }

        public string Senha { get; set; }

        public string Token { get; set; }

        public bool Autenticado { get; set; }

        public AutenticaTransfer()
        {
            this.Autenticado = false;
            this.Token = null;
        }

        public AutenticaTransfer(AutenticaTransfer pTransfer)
        {
            if (pTransfer != null) {
                this.Apelido = pTransfer.Apelido;
                this.Senha = pTransfer.Senha;
                this.Token = pTransfer.Token;
                this.Autenticado = pTransfer.Autenticado;
            }
        }
    }
}