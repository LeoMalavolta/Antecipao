using Antecipacao.Domain.Base;

namespace Antecipacao.Domain.Entities
{
    public class CarrinhoAntecipacao : Entity
    {
        public DateTime? DataAntecipacao { get; private set; }
        public decimal? ValorTotalBruto { get; private set; }
        public decimal? ValorTotalLiquido { get; private set; }

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
            var totalCarrinho = _notasFiscais.Sum(n => n.ValorBruto) + notaFiscal.ValorBruto;

            if (totalCarrinho > limiteCreditoAtual)
                throw new InvalidOperationException("O valor do carrinho ultrapassa o limite da empresa.");

            _notasFiscais.Add(notaFiscal);
            ValorTotalBruto = totalCarrinho;
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
            var resultadoNotas = new List<object>();
            decimal valorTotalLiquido = 0m;
            var dataAtual = DateTime.UtcNow;
            var taxa = 0.0465m;

            foreach (var nota in _notasFiscais)
            {
                var prazo = dataAtual.Day - nota.DataVencimento.Day;
                var desagio = nota.ValorBruto / (decimal)Math.Pow((double)(1 + taxa), (double)prazo / 30);
                var valorLiquido = nota.ValorBruto - desagio;

                nota.AlterarValorLiquido(valorLiquido);
                valorTotalLiquido += valorLiquido;
            }

            ValorTotalLiquido = valorTotalLiquido;
        }
    }
}
