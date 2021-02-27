namespace rcLogTransfers
{
    public abstract class TransferBase : TransferValidacao
    {
        public TransferFiltro Filtro { get; set; }

        public TransferPaginacao Paginacao { get; set; }

        public TransferBase() : base()
        {
            this.Filtro = new TransferFiltro();
            this.Paginacao = new TransferPaginacao();
        }

        public TransferBase(TransferBase transfer) : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Filtro != null) {
                    this.Filtro = new TransferFiltro(transfer.Filtro);
                }
                if (transfer.Paginacao != null) {
                    this.Paginacao = new TransferPaginacao(transfer.Paginacao);
                }
            }
        }
    }
}
