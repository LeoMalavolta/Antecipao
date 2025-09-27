namespace Antecipacao.Domain.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Excluido{ get; set; }
        public DateTime? DataExclusao { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
            Excluido = false;
        }

        public virtual void Excluir()
        {
            Excluido = true;
            DataExclusao = DateTime.UtcNow;
        }
    }
}
