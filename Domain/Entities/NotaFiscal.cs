using Antecipacao.Domain.Base;

namespace Antecipacao.Domain.Entities
{
    public class NotaFiscal : Entity
    {
        public Guid IdEmpresa { get; private set; }
        public string Numero { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataVencimento { get; private set; }

        private NotaFiscal(Guid idEmpresa, string numero, decimal valor, DateTime dataVencimento)
        {
            IdEmpresa = idEmpresa;
            Numero = numero;
            Valor = valor;
            DataVencimento = dataVencimento;
        }

        public static NotaFiscal Criar(Guid idEmpresa, string numero, decimal valor, DateTime dataVencimento)
        {
            if (idEmpresa == Guid.Empty)
                throw new ArgumentException("IdEmpresa é obrigatório.");

            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Número da nota fiscal é obrigatório.");

            if (valor <= 0)
                throw new ArgumentException("Valor da nota fiscal deve ser maior que zero.");

            if (dataVencimento < DateTime.UtcNow.Date)
                throw new ArgumentException("Data de vencimento não pode ser no passado.");

            return new NotaFiscal(idEmpresa, numero, valor, dataVencimento);
        }
    }
}
