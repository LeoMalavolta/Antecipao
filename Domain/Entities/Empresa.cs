using Antecipacao.Domain.Base;
using Antecipacao.Domain.Enums;

namespace Antecipacao.Domain.Entities
{
    public class Empresa : Entity
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public RamoEmpresa RamoEmpresa { get; private set; }
        public IReadOnlyList<FaturamentoMensal> Faturamento => _faturamento;
        public IReadOnlyList<CarrinhoAntecipacao> Carrinho => _carrinho;

        private List<FaturamentoMensal> _faturamento = new List<FaturamentoMensal>();
        private List<CarrinhoAntecipacao> _carrinho = new List<CarrinhoAntecipacao>();

        protected Empresa() { }

        public Empresa(string nome, string cnpj, int ramoEmpresa)
        {
            AlterarNome(nome);
            AlterarCnpj(cnpj);
            AlterarRamoEmpresa(ramoEmpresa);
        }

        public void AlterarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da empresa é obrigatório.");

            Nome = nome;
        }

        public void AlterarCnpj(string cnpj)
        {
            if (!Utils.ValidarCnpj(cnpj))
                throw new ArgumentException("CNPJ inválido.");

            Cnpj = Utils.RemoverNaoNumericos(cnpj);
        }

        public void AlterarRamoEmpresa(int ramoEmpresa)
        {
            if (!Enum.IsDefined(typeof(RamoEmpresa), ramoEmpresa))
                throw new ArgumentException("Ramo da empresa inválido.");

            RamoEmpresa = (RamoEmpresa)ramoEmpresa;
        }

        public void AdicionarFaturamento(FaturamentoMensal faturamento)
        {
            if (faturamento == null) throw new ArgumentNullException(nameof(faturamento));
            _faturamento.Add(faturamento);
        }

        public void AdicionarCarrinho(CarrinhoAntecipacao carrinho)
        {
            if (carrinho == null) throw new ArgumentNullException(nameof(carrinho));
            _carrinho.Add(carrinho);
        }
    }
}
