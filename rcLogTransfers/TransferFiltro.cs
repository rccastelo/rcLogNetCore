using System;

namespace rcLogTransfers
{
    public class TransferFiltro
    {
        public int IdDe { get; set; }

        public int IdAte { get; set; }

        public string Descricao { get; set; }

        public string Codigo { get; set; }

        public string Ativo { get; set; }

        public DateTime CriacaoDe { get; set; }
        
        public DateTime CriacaoAte { get; set; }

        public DateTime AlteracaoDe { get; set; }
        
        public DateTime AlteracaoAte { get; set; }

         public TransferFiltro()
        {
        }

        public TransferFiltro(TransferFiltro pTransfer)
        {
            if (pTransfer != null) {
                this.IdDe = pTransfer.IdDe;
                this.IdAte = pTransfer.IdAte;
                this.Descricao = pTransfer.Descricao;
                this.Codigo = pTransfer.Codigo;
                this.Ativo = pTransfer.Ativo;
                this.CriacaoDe = pTransfer.CriacaoDe;
                this.CriacaoAte = pTransfer.CriacaoAte;
                this.AlteracaoDe = pTransfer.AlteracaoDe;
                this.AlteracaoAte = pTransfer.AlteracaoAte;
            }
        }
    }
}