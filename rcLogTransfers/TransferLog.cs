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

        public TransferLog(TransferLog transfer)
        {
            if (transfer != null) {
                this.Validacao = transfer.Validacao;
                this.Erro = transfer.Erro;
                if (transfer.Mensagens != null) {
                    this.Mensagens = new List<string>(transfer.Mensagens);
                }
                if (transfer.Filtro != null) {
                    this.Filtro = new TransferFiltro(transfer.Filtro);
                }
                if (transfer.Paginacao != null) {
                    this.Paginacao = new TransferPaginacao(transfer.Paginacao);
                }
            }
        }

        public void IncluirMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem)) {
                if (this.Mensagens == null) {
                    this.Mensagens = new List<string>();
                }

                this.Mensagens.Add(mensagem);
            }
        }
    }
}
