using Antecipacao.Domain.Base;

namespace Antecipacao.Domain.Entities
{
    public class NotaFiscal : Entity
    {
        public string Numero { get; private set; }
        public decimal ValorBruto { get; private set; }
        public decimal? ValorLiquido { get; private set; }
        public DateTime DataVencimento { get; private set; }

        public Guid IdEmpresa { get; private set; }
        public Empresa Empresa { get; private set; }

   
        public Guid? IdCarrinho { get; private set; }
        public CarrinhoAntecipacao? Carrinho { get; private set; }

        protected NotaFiscal() { }

        public NotaFiscal(Guid idEmpresa, Guid? idCarrinho, string numero, decimal valor, DateTime dataVencimento)
        {
            AlterarEmpresa(idEmpresa);
            AlterarCarrinho(idCarrinho);
            AlterarNumero(numero);
            AlterarValorBruto(valor);
            AlterarDataVencimento(dataVencimento);
        }

        public void AlterarEmpresa(Guid idEmpresa)
        {
            if (idEmpresa == Guid.Empty)
                throw new ArgumentException("Empresa é obrigatório.");

            IdEmpresa = idEmpresa;
        }

        public void AlterarCarrinho(Guid? idCarrinho)
        {
            if (idCarrinho == Guid.Empty)
                throw new ArgumentException("IdCarrinho empty.");

            IdCarrinho = idCarrinho;
        }

        public void AlterarNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Número da nota fiscal é obrigatório.");

            Numero = numero;
            Atualizar();
        }

        public void AlterarValorBruto(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor da nota fiscal deve ser maior que zero.");

            ValorBruto = valor;
            Atualizar();
        }

        public void AlterarValorLiquido(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor da nota fiscal deve ser maior que zero.");

            ValorLiquido = valor;
            Atualizar();
        }

        public void AlterarDataVencimento(DateTime dataVencimento)
        {
            if (dataVencimento < DateTime.UtcNow.Date)
                throw new ArgumentException("Data de vencimento não pode ser no passado.");

            DataVencimento = dataVencimento;
            Atualizar();
        }
    }
}
