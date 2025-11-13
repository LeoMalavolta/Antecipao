namespace BuildingBlocks.Core.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            DataAtualizacao = DateTime.UtcNow;
            DataCriacao = DateTime.UtcNow;
        }

        public virtual void Atualizar()
        {
            DataAtualizacao = DateTime.UtcNow;
        }

        public virtual void Excluir()
        {
            DataExclusao = DateTime.UtcNow;
        }
    }
}
