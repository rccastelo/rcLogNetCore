namespace rcLogTransfers
{
    public class TransferPaginacao
    {
        public int PaginaAtual { get; set; }

        public int PaginaInicial { get; set; }

        public int PaginaFinal { get; set; }

        public int RegistrosPorPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPaginas { get; set; }

        public TransferPaginacao()
        {
        }

        public TransferPaginacao(TransferPaginacao pTransfer)
        {
            if (pTransfer != null) {
                this.PaginaAtual = pTransfer.PaginaAtual;
                this.PaginaInicial = pTransfer.PaginaInicial;
                this.PaginaFinal = pTransfer.PaginaFinal;
                this.RegistrosPorPagina = pTransfer.RegistrosPorPagina;
                this.TotalRegistros = pTransfer.TotalRegistros;
                this.TotalPaginas = pTransfer.TotalPaginas;
            }
        }
    }
}