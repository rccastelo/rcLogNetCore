namespace rcLogEntities
{
  public class SistemaEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public bool Ativo { get; set; }        

        public SistemaEntity()
        {
        }

        public SistemaEntity(int id, string nome, string descricao, string codigo, bool ativo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Codigo = codigo;
            this.Ativo = ativo;
        }

        public SistemaEntity(SistemaEntity sistema)
        {
            if (sistema != null) {
                this.Id = sistema.Id;
                this.Nome = sistema.Nome;
                this.Descricao = sistema.Descricao;
                this.Codigo = sistema.Codigo;
                this.Ativo = sistema.Ativo;
            }
        }
    }
}
