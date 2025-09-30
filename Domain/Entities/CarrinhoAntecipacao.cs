using Antecipacao.Domain.Base;

namespace Antecipacao.Domain.Entities
{
    public class CarrinhoAntecipacao : Entity
    {
        public DateTime? DataAntecipacao { get; private set; }

        public Guid IdEmpresa { get; private set; }
        public Empresa Empresa { get; private set; }
        public IReadOnlyList<NotaFiscal> NotasFiscais => _notasFiscais;

        private List<NotaFiscal> _notasFiscais = new List<NotaFiscal>();

        protected CarrinhoAntecipacao() { }

        public CarrinhoAntecipacao(Guid idEmpresa)
        {
            AlterarEmpresa(idEmpresa);
        }

        private void AlterarEmpresa(Guid empresaId)
        {
            if (empresaId == Guid.Empty)
                throw new ArgumentException("Empresa é obrigatório.");

            IdEmpresa = empresaId;
        }

        public void AdicionarNota(NotaFiscal notaFiscal, decimal limiteCreditoAtual)
        {
            var totalCarrinho = _notasFiscais.Sum(n => n.Valor) + notaFiscal.Valor;

            if (totalCarrinho > limiteCreditoAtual)
                throw new InvalidOperationException("O valor do carrinho ultrapassa o limite da empresa.");

            _notasFiscais.Add(notaFiscal);
            Atualizar();
        }

        public void RemoverNota(Guid idNota)
        {
            var nota = _notasFiscais.FirstOrDefault(n => n.Id == idNota);
            if (nota != null)
                _notasFiscais.Remove(nota);

            Atualizar();
        }

        public void Checkout()
        {
            if (ValidarCheckout())
            {

            }
        }

        private bool ValidarCheckout()
        {
            return true;
        }
    }
}
