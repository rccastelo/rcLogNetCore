using System.Collections.Generic;

namespace rcLogTransfers
{
    public abstract class TransferLog
    {
        public TransferFiltro Filtro { get; set; }

        public TransferPaginacao Paginacao { get; set; }

        public bool Validacao { get; set; } 

        public bool Erro { get; set; }

        public IList<string> Mensagens { get; set; }

        public TransferLog()
        {
            this.Filtro = new TransferFiltro();
            this.Paginacao = new TransferPaginacao();
            this.Validacao = true;
            this.Erro = false;
        }

        public TransferLog(TransferLog pTransfer)
        {
            if (pTransfer != null) {
                this.Validacao = pTransfer.Validacao;
                this.Erro = pTransfer.Erro;
                if (pTransfer.Mensagens != null) {
                    this.Mensagens = new List<string>(pTransfer.Mensagens);
                }
                if (pTransfer.Filtro != null) {
                    this.Filtro = new TransferFiltro(pTransfer.Filtro);
                }
                if (pTransfer.Paginacao != null) {
                    this.Paginacao = new TransferPaginacao(pTransfer.Paginacao);
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
