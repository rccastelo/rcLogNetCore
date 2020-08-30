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

        public TransferFiltro(TransferFiltro transfer)
        {
            if (transfer != null) {
                this.IdDe = transfer.IdDe;
                this.IdAte = transfer.IdAte;
                this.Descricao = transfer.Descricao;
                this.Codigo = transfer.Codigo;
                this.Ativo = transfer.Ativo;
                this.CriacaoDe = transfer.CriacaoDe;
                this.CriacaoAte = transfer.CriacaoAte;
                this.AlteracaoDe = transfer.AlteracaoDe;
                this.AlteracaoAte = transfer.AlteracaoAte;
            }
        }
    }
}