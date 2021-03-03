using System.Collections.Generic;
using rcLogEntities;

namespace rcLogTransfers
{
    public class LogTransfer : TransferValidacao
    {
        public LogEntity Log { get; set; }

        public IList<LogEntity> Lista { get; set; }

        public TransferPaginacao Paginacao { get; set; }

        public LogTransfer()
        {
            this.Paginacao = new TransferPaginacao();
        }

        public LogTransfer(LogTransfer transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<LogEntity>(transfer.Lista);
                }
                if (transfer.Log != null) {
                    this.Log = new LogEntity(transfer.Log);
                }
                if (transfer.Paginacao != null) {
                    this.Paginacao = new TransferPaginacao(transfer.Paginacao);
                }
            }
        }

        public void Incluir(LogEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<LogEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
