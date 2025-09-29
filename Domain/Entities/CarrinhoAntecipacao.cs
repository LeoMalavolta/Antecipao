using Antecipacao.Domain.Base;

namespace Antecipacao.Domain.Entities
{
    public class CarrinhoAntecipacao : Entity
    {
        public Guid IdEmpresa { get; private set; }
        public decimal ValorTotalBruto { get; private set; }
        public decimal ValorTotalLiquido { get; private set; }
        public ICollection<NotaFiscal> NotasFiscais { get; private set; }
        public DateTime? DataAntecipacao { get; private set; }

        protected CarrinhoAntecipacao() { } 

        public CarrinhoAntecipacao(Guid idEmpresa, decimal valorTotalBruto, decimal valorTotalLiquido)
        {
            AlterarEmpresa(idEmpresa);
            AlterarValorTotalBruto(valorTotalBruto);
            AlterarValorTotalLiquido(valorTotalLiquido);
        }

        public void AlterarEmpresa(Guid empresaId)
        {
            if (empresaId == Guid.Empty)
                throw new ArgumentException("Empresa é obrigatório.");

            IdEmpresa = empresaId;
        }

        public void AlterarValorTotalBruto(decimal valorTotalBruto)
        {
            if (valorTotalBruto <= 0)
                throw new ArgumentException("Valor antecipado deve ser maior que zero.");

            ValorTotalBruto = valorTotalBruto;
        }

        public void AlterarValorTotalLiquido(decimal valorTotalLiquido)
        {
            if (valorTotalLiquido <= 0)
                throw new ArgumentException("Valor antecipado deve ser maior que zero.");

            ValorTotalLiquido = valorTotalLiquido;
        }

        public void DefinirDataAntecipacao(DateTime dataAntecipacao)
        {
            if (dataAntecipacao < DateTime.UtcNow)
                throw new ArgumentException("Data de antecipação não pode ser no passado.");

            DataAntecipacao = dataAntecipacao;
        }
    }
}
