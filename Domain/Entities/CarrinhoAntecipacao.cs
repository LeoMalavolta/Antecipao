using BuildingBlocks.Core.Domain.Entities;
using BuildingBlocks.Exceptions.Domain;

namespace BuildingBlocks.Core.Entities
{
    public class CarrinhoAntecipacao : Entity
    {
        public DateTime? DataAntecipacao { get; private set; }
        public decimal? ValorTotalBruto { get; private set; }
        public decimal? ValorTotalLiquido { get; private set; }

        public Guid IdEmpresa { get; private set; }
        public Empresa Empresa { get; private set; }

        private readonly List<NotaFiscal> _notasFiscais = new();
        public IReadOnlyCollection<NotaFiscal> NotasFiscais => _notasFiscais.AsReadOnly();

        protected CarrinhoAntecipacao() { }

        public CarrinhoAntecipacao(Guid idEmpresa)
        {
            AlterarEmpresa(idEmpresa);
        }

        private void AlterarEmpresa(Guid empresaId)
        {
            if (empresaId == Guid.Empty)
                throw new DomainException("Empresa é obrigatório.");

            IdEmpresa = empresaId;
        }

        public void AdicionarNota(NotaFiscal notaFiscal, decimal limiteCreditoAtual)
        {
            if (notaFiscal.IdCarrinho is not null)
                throw new InvalidOperationException("A nota já está vinculada a um carrinho.");

            var totalCarrinho = _notasFiscais.Sum(n => n.ValorBruto) + notaFiscal.ValorBruto;

            if (totalCarrinho > limiteCreditoAtual)
                throw new InvalidOperationException("O valor do carrinho ultrapassa o limite da empresa.");

            _notasFiscais.Add(notaFiscal);
            ValorTotalBruto = totalCarrinho;
            Atualizar();
        }

        public void RemoverNota(Guid idNota)
        {
            if (idNota == Guid.Empty)
                throw new DomainException("idNota é obrigatório.");

            var nota = _notasFiscais.FirstOrDefault(n => n.Id == idNota);
            if (nota != null)
                _notasFiscais.Remove(nota);

            ValorTotalBruto = _notasFiscais.Sum(n => n.ValorBruto);

            Atualizar();
        }

        public void Checkout()
        {
            DataAntecipacao = DateTime.UtcNow;
            Atualizar();
        }
    }
}
