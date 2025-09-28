using Antecipacao.Domain.Base;

namespace Antecipacao.Domain.Entities
{
    public class CarrinhoAntecipacao : Entity
    {
        public Guid IdEmpresa { get; private set; }
        public decimal ValorTotalBruto { get; private set; }
        public decimal ValorTotalLiquido { get; private set; }
        public ICollection<NotaFiscal> NotasFiscais { get; private set; }
        public bool Antecipado { get; private set; }
        public DateTime? DataAntecipacao { get; private set; }

        private CarrinhoAntecipacao(Guid idEmpresa, decimal valorTotalBruto, decimal valorTotalLiquido, IEnumerable<NotaFiscal> notasFiscais)
        {
            IdEmpresa = idEmpresa;
            ValorTotalBruto = valorTotalBruto;
            ValorTotalLiquido = valorTotalLiquido;
            NotasFiscais = notasFiscais.ToList();
        }

        public static CarrinhoAntecipacao Criar(Guid empresaId, decimal valorTotalBruto, decimal valorTotalLiquido, ICollection<NotaFiscal> notaFiscals)
        {
            if (empresaId == Guid.Empty)
                throw new ArgumentException("EmpresaId é obrigatório.");

            if (valorTotalBruto <= 0)
                throw new ArgumentException("Valor antecipado deve ser maior que zero.");

            if (valorTotalLiquido <= 0)
                throw new ArgumentException("Valor antecipado deve ser maior que zero.");

            return new CarrinhoAntecipacao(empresaId, valorTotalBruto, valorTotalLiquido, notaFiscals);
        }
    }
}
