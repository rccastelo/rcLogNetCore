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

        public SistemaEntity(int pIid, string pNome, string pDescricao, string pCodigo, bool pAtivo)
        {
            this.Id = pIid;
            this.Nome = pNome;
            this.Descricao = pDescricao;
            this.Codigo = pCodigo;
            this.Ativo = pAtivo;
        }

        public SistemaEntity(SistemaEntity pSistema)
        {
            if (pSistema != null) {
                this.Id = pSistema.Id;
                this.Nome = pSistema.Nome;
                this.Descricao = pSistema.Descricao;
                this.Codigo = pSistema.Codigo;
                this.Ativo = pSistema.Ativo;
            }
        }
    }
}
