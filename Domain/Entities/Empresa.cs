using Antecipacao.Domain.Base;
using Antecipacao.Domain.Enums;
using System.ComponentModel;

namespace Antecipacao.Domain.Entities
{
    public class Empresa : Entity
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public decimal Limite { get; private set; }
        public RamoEmpresa RamoEmpresa { get; private set; }

        public IReadOnlyList<FaturamentoMensal> Faturamento => _faturamento;
        public IReadOnlyList<NotaFiscal> NotasFiscais => _notasFiscais;
        public IReadOnlyList<CarrinhoAntecipacao> Carrinho => _carrinho;

        private List<FaturamentoMensal> _faturamento = new List<FaturamentoMensal>();
        private List<NotaFiscal> _notasFiscais = new List<NotaFiscal>();
        private List<CarrinhoAntecipacao> _carrinho = new List<CarrinhoAntecipacao>();

        protected Empresa() { }

        public Empresa(string nome, string cnpj, decimal faturamentoMensal, int ramoEmpresa)
        {
            AlterarNome(nome);
            AlterarCnpj(cnpj);
            AlterarRamoEmpresa(ramoEmpresa);
            CalcularLimite(faturamentoMensal);
        }

        public void AlterarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da empresa é obrigatório.");

            Nome = nome;
            Atualizar();
        }

        public void AlterarCnpj(string cnpj)
        {
            if (!Utils.ValidarCnpj(cnpj))
                throw new ArgumentException("CNPJ inválido.");

            Cnpj = Utils.RemoverNaoNumericos(cnpj);
            Atualizar();
        }

        public void AlterarRamoEmpresa(int ramoEmpresa)
        {
            if (!Enum.IsDefined(typeof(RamoEmpresa), ramoEmpresa))
                throw new ArgumentException("Ramo da empresa inválido.");

            RamoEmpresa = (RamoEmpresa)ramoEmpresa;
            Atualizar();
        }

        public void AdicionarFaturamento(FaturamentoMensal faturamento)
        {
            if (faturamento == null) throw new ArgumentNullException(nameof(faturamento));
            _faturamento.Add(faturamento);
        }

        public void CalcularLimite(decimal? faturamentoMensal = null)
        {
            var mediaFaturamento = CalcularMediaFaturamento(faturamentoMensal);

            if (RamoEmpresa == RamoEmpresa.Servicos)
                Limite = CalcularLimiteServicos(mediaFaturamento);
            else if (RamoEmpresa == RamoEmpresa.Produtos)
                Limite = CalcularLimiteProdutos(mediaFaturamento);
            else
                throw new ArgumentException("Ramo da empresa inválido.");
        }

        private decimal CalcularMediaFaturamento(decimal? faturamentoMensal = null)
        {
            if (faturamentoMensal.HasValue)
                return faturamentoMensal.Value;

            var dataCorte = DateTime.UtcNow.AddMonths(-12);
            var faturamentos = _faturamento
                .Where(f => f.Periodo >= dataCorte)
                .ToList();

            if (!faturamentos.Any())
                throw new InvalidOperationException("Empresa não possui faturamento registrado para cálculo do limite.");

            return faturamentos.Average(f => f.Valor);
        }

        public decimal CalcularLimiteServicos(decimal totalFaturamento)
        {
            if (totalFaturamento >= 10000 && totalFaturamento <= 50000)
                return totalFaturamento * 0.50m;
            else if (totalFaturamento >= 50001 && totalFaturamento <= 100000)
                return totalFaturamento * 0.55m;
            else if (totalFaturamento > 100000)
                return totalFaturamento * 0.60m;
            else
                return 0;
        }

        public decimal CalcularLimiteProdutos(decimal totalFaturamento)
        {
            if (totalFaturamento >= 10000 && totalFaturamento <= 50000)
                return totalFaturamento * 0.50m;
            else if (totalFaturamento >= 50001 && totalFaturamento <= 100000)
                return totalFaturamento * 0.60m;
            else if (totalFaturamento > 100000)
                return totalFaturamento * 0.65m;
            else
                return 0;
        }
    }
}
