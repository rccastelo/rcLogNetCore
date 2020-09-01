using System.Collections.Generic;
using rcLogEntities;

namespace rcLogTransfers
{
    public class SistemaTransfer : TransferLog
    {
        public SistemaEntity Sistema { get; set; }

        public IList<SistemaEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.Sistema != null) ? this.Sistema.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Incluir", 
                    uri = "/rcLog/Sistema", 
                    method = "POST"
                }
            };
            
            this.Links = obj;
        }

        public SistemaTransfer() 
            : base()
        {
        }

        public SistemaTransfer(SistemaTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<SistemaEntity>(transfer.Lista);
                }
                if (transfer.Sistema != null) {
                    this.Sistema = new SistemaEntity(transfer.Sistema);
                }
                this.Links = transfer.Links;
            }
        }

        public void IncluirSistema(SistemaEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<SistemaEntity>();
                }

                this.Lista.Add(entity);
            }
        }
        
    }
}