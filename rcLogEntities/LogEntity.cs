namespace rcLogEntities
{
    public class LogEntity
    {
        public long Id { get; set; }
        public int Data { get; set; }
        public int Hora { get; set; }
        public string Chave { get; set; }
        public string Ip { get; set; }
        public int Sistema { get; set; }
        public string Modulo { get; set; }
        public string Arquivo { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public string Mensagem { get; set; }
        public string Pilha { get; set; }
        public string Origem { get; set; }
        public bool Critico { get; set; }

        public LogEntity()
        {
        }

        public LogEntity(int pId, int pData, int pHora, string pChave, string pIp, int pSistema, string pModulo, 
            string pArquivo, int pTipo, string pDescricao, string pMensagem, string pPilha, string pOrigem, bool pCritico)
        {
            this.Id = pId;
            this.Data = pData;
            this.Hora = pHora;
            this.Chave = pChave;
            this.Ip = pIp;
            this.Sistema = pSistema;
            this.Modulo = pModulo;
            this.Arquivo = pArquivo;
            this.Tipo = pTipo;
            this.Descricao = pDescricao;
            this.Mensagem = pMensagem;
            this.Pilha = pPilha;
            this.Origem = pOrigem;
            this.Critico = pCritico;
        }

        public LogEntity(LogEntity pSistema)
        {
            if (pSistema != null) {
                this.Id = pSistema.Id;
                this.Data = pSistema.Data;
                this.Hora = pSistema.Hora;
                this.Chave = pSistema.Chave;
                this.Ip = pSistema.Ip;
                this.Sistema = pSistema.Sistema;
                this.Modulo = pSistema.Modulo;
                this.Arquivo = pSistema.Arquivo;
                this.Tipo = pSistema.Tipo;
                this.Descricao = pSistema.Descricao;
                this.Mensagem = pSistema.Mensagem;
                this.Pilha = pSistema.Pilha;
                this.Origem = pSistema.Origem;
                this.Critico = pSistema.Critico;
            }
        }
    }
}
