using System.Collections.Generic;
using rcLogEntities;

namespace rcLogTransfers
{
    public class LogTransfer : TransferLog
    {
        public LogEntity Log { get; set; }

        public IList<LogEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.Log != null) ? this.Log.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Incluir", 
                    uri = "/rcLog/Log", 
                    method = "POST"
                }
            };
            
            this.Links = obj;
        }

        public LogTransfer() 
            : base()
        {
        }

        public LogTransfer(LogTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<LogEntity>(transfer.Lista);
                }
                if (transfer.Log != null) {
                    this.Log = new LogEntity(transfer.Log);
                }
                this.Links = transfer.Links;
            }
        }

        public void IncluirLog(LogEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<LogEntity>();
                }

                this.Lista.Add(entity);
            }
        }
        
    }
}