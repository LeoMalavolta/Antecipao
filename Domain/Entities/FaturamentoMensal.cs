using BuildingBlocks.Core.Domain.Entities;
using BuildingBlocks.Exceptions.Domain;

namespace BuildingBlocks.Core.Entities
{
    public class FaturamentoMensal : Entity
    {
        public decimal Valor { get; private set; }
        public DateTime Periodo { get; private set; }

        public Guid IdEmpresa { get; private set; }
        public Empresa Empresa { get; private set; }

        protected FaturamentoMensal() { }

        public FaturamentoMensal(Guid idEmpresa, decimal valor, DateTime periodo)
        {
            AlterarEmpresa(idEmpresa);
            AlterarValor(valor);
            AlterarPeriodo(periodo);
        }

        private void AlterarEmpresa(Guid idEmpresa)
        {
            if (idEmpresa == Guid.Empty)
                throw new DomainException("IdEmpresa é obrigatório.");

            IdEmpresa = idEmpresa;
        }

        public void AlterarValor(decimal valor)
        {
            if (valor < 0)
                throw new DomainException("O valor do faturamento não pode ser negativo.");

            Valor = valor;
        }

        public void AlterarPeriodo(DateTime periodo)
        {
            if (periodo > DateTime.UtcNow)
                throw new DomainException("Periodo inválido.");

            Periodo = periodo;
        }
    }
}
