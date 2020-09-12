using System.Collections.Generic;

namespace rcLogTransfers
{
    public abstract class Transfer
    {
        public bool Validacao { get; set; } 

        public bool Erro { get; set; }

        public IList<string> Mensagens { get; set; }

        public Transfer()
        {
            this.Validacao = true;
            this.Erro = false;
        }

        public Transfer(Transfer pTransfer)
        {
            if (pTransfer != null) {
                this.Validacao = pTransfer.Validacao;
                this.Erro = pTransfer.Erro;
                if (pTransfer.Mensagens != null) {
                    this.Mensagens = new List<string>(pTransfer.Mensagens);
                }
            }
        }

        public void IncluirMensagem(string pMensagem)
        {
            if (!string.IsNullOrEmpty(pMensagem)) {
                if (this.Mensagens == null) {
                    this.Mensagens = new List<string>();
                }

                this.Mensagens.Add(pMensagem);
            }
        }
    }
}
