using Antecipacao.Domain.Base;
using Antecipacao.Domain.Enums;

namespace Antecipacao.Domain.Entities
{
    public class Empresa : Entity
    {
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public RamoEmpresa RamoEmpresa { get; private set; }
        public ICollection<FaturamentoMensal> Faturamento { get; private set; }
        public ICollection<CarrinhoAntecipacao> Carrinho { get; private set; }

        private Empresa(string nome, string cnpj, RamoEmpresa ramoEmpresa, ICollection<FaturamentoMensal> faturamento, ICollection<CarrinhoAntecipacao> carrinho)
        {
            Nome = nome;
            Cnpj = Utils.RemoverNaoNumericos(cnpj);
            RamoEmpresa = ramoEmpresa;
            Faturamento = faturamento;
            Carrinho = carrinho;
        }

        public static Empresa Criar(string nome, string cnpj, RamoEmpresa ramoEmpresa, ICollection<FaturamentoMensal> faturamentos, ICollection<CarrinhoAntecipacao> carrinho)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da empresa é obrigatório.");

            if (!Utils.ValidarCnpj(cnpj))
                throw new ArgumentException("CNPJ inválido.");

            if (!Enum.IsDefined(typeof(RamoEmpresa), ramoEmpresa))
                throw new ArgumentException("Ramo da empresa inválido.");

            return new Empresa(nome, cnpj, ramoEmpresa, faturamentos, carrinho);
        }
    }
}
