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
            var obj = new object[] {
                new {
                    info = "Consultar", 
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

        public LogTransfer(LogTransfer pTransfer) 
            : base(pTransfer)
        {
            if (pTransfer != null) {
                if (pTransfer.Lista != null) {
                    this.Lista = new List<LogEntity>(pTransfer.Lista);
                }
                if (pTransfer.Log != null) {
                    this.Log = new LogEntity(pTransfer.Log);
                }
                this.Links = pTransfer.Links;
            }
        }

        public void IncluirLog(LogEntity pEntity) {
            if (pEntity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<LogEntity>();
                }

                this.Lista.Add(pEntity);
            }
        }
        
    }
}