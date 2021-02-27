namespace rcLogEntities
{
    public class LogEntity
    {
        public string Sistema { get; set; }
        public int Data { get; set; }
        public int Hora { get; set; }
        public string Controle { get; set; }
        public string Ip { get; set; }
        public int Tipo { get; set; }
        public string Mensagem { get; set; }
        public string Pilha { get; set; }
        public string Origem { get; set; }
        public bool Critico { get; set; }

        public LogEntity()
        {
        }

        public LogEntity(string sistema, int data, int hora, string controle, string ip, 
            int tipo, string mensagem, string pilha, string origem, bool critico)
        {
            this.Sistema = sistema;
            this.Data = data;
            this.Hora = hora;
            this.Controle = controle;
            this.Ip = ip;
            this.Tipo = tipo;
            this.Mensagem = mensagem;
            this.Pilha = pilha;
            this.Origem = origem;
            this.Critico = critico;
        }

        public LogEntity(LogEntity log)
        {
            if (log != null) {
                this.Sistema = log.Sistema;
                this.Data = log.Data;
                this.Hora = log.Hora;
                this.Controle = log.Controle;
                this.Ip = log.Ip;
                this.Tipo = log.Tipo;
                this.Mensagem = log.Mensagem;
                this.Pilha = log.Pilha;
                this.Origem = log.Origem;
                this.Critico = log.Critico;
            }
        }
    }
}
