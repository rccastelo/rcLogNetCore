using System.Collections.Generic;
using rcLogEntities;

namespace rcLogTransfers
{
    public class SistemaTransfer : TransferLog
    {
        public SistemaEntity Sistema { get; set; }

        public IList<SistemaEntity> Lista { get; set; }

        public object Links { get; set; }

        public int teste { get; set; }

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

        public SistemaTransfer(SistemaTransfer pTransfer) 
            : base(pTransfer)
        {
            if (pTransfer != null) {
                if (pTransfer.Lista != null) {
                    this.Lista = new List<SistemaEntity>(pTransfer.Lista);
                }
                if (pTransfer.Sistema != null) {
                    this.Sistema = new SistemaEntity(pTransfer.Sistema);
                }
                this.Links = pTransfer.Links;
            }
        }

        public void IncluirSistema(SistemaEntity pEntity) {
            if (pEntity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<SistemaEntity>();
                }

                this.Lista.Add(pEntity);
            }
        }
        
    }
}