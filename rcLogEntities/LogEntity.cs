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

        public LogEntity(int id, int data, int hora, string chave, string ip, int sistema, string modulo, 
            string arquivo, int tipo, string descricao, string mensagem, string pilha, string origem, bool critico)
        {
            this.Id = id;
            this.Data = data;
            this.Hora = hora;
            this.Chave = chave;
            this.Ip = ip;
            this.Sistema = sistema;
            this.Modulo = modulo;
            this.Arquivo = arquivo;
            this.Tipo = tipo;
            this.Descricao = descricao;
            this.Mensagem = mensagem;
            this.Pilha = pilha;
            this.Origem = origem;
            this.Critico = critico;
        }

        public LogEntity(LogEntity sistema)
        {
            if (sistema != null) {
                this.Id = sistema.Id;
                this.Data = sistema.Data;
                this.Hora = sistema.Hora;
                this.Chave = sistema.Chave;
                this.Ip = sistema.Ip;
                this.Sistema = sistema.Sistema;
                this.Modulo = sistema.Modulo;
                this.Arquivo = sistema.Arquivo;
                this.Tipo = sistema.Tipo;
                this.Descricao = sistema.Descricao;
                this.Mensagem = sistema.Mensagem;
                this.Pilha = sistema.Pilha;
                this.Origem = sistema.Origem;
                this.Critico = sistema.Critico;
            }
        }
    }
}
