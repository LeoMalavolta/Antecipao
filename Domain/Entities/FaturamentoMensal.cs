using Antecipacao.Domain.Base;
using Antecipacao.Domain.Enums;

namespace Antecipacao.Domain.Entities
{
    public class FaturamentoMensal : Entity
    {
        public Guid IdEmpresa { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Periodo { get; private set; }

        private FaturamentoMensal(Guid idEmpresa, decimal valor, DateTime periodo)
        {
            IdEmpresa = idEmpresa;
            Valor = valor;
            Periodo = periodo;
        }

        public static FaturamentoMensal Criar(Guid idEmpresa, decimal valor, DateTime periodo)
        {
            if (idEmpresa == Guid.Empty)
                throw new ArgumentException("IdEmpresa é obrigatório.");

            if (valor < 0)
                throw new ArgumentException("O valor do faturamento não pode ser negativo.");

            if (periodo < DateTime.Now)
                throw new ArgumentException("Periodo inválido.");

            return new FaturamentoMensal(idEmpresa, valor, periodo);
        }
    }
}
