using System;

namespace rcLogTransfers
{
    public class TransferFiltro
    {
        public int Id { get; set; }

         public TransferFiltro()
        {
        }

        public TransferFiltro(TransferFiltro transfer)
        {
            if (transfer != null) {
                this.Id = transfer.Id;
            }
        }
    }
}
