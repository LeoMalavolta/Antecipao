using Antecipacao.Domain.Base;

namespace Antecipacao.Domain.Entities
{
    public class NotaFiscal : Entity
    {
        public Guid? IdCarrinho { get; private set; }
        public string Numero { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataVencimento { get; private set; }

        protected NotaFiscal() { }

        public NotaFiscal(Guid? idCarrinho, string numero, decimal valor, DateTime dataVencimento)
        {
            AlterarCarrinho(idCarrinho);
            AlterarNumero(numero);
            AlterarValor(valor);
            AlterarDataVencimento(dataVencimento);
        }

        public void AlterarCarrinho(Guid? idCarrinho)
        {
            if (idCarrinho == Guid.Empty)
                throw new ArgumentException("IdCarrinho é obrigatório.");

            IdCarrinho = idCarrinho;
        }

        public void AlterarNumero(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Número da nota fiscal é obrigatório.");

            Numero = numero;
        }

        public void AlterarValor(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor da nota fiscal deve ser maior que zero.");

            Valor = valor;
        }

        public void AlterarDataVencimento(DateTime dataVencimento)
        {
            if (dataVencimento < DateTime.UtcNow.Date)
                throw new ArgumentException("Data de vencimento não pode ser no passado.");

            DataVencimento = dataVencimento;
        }
    }
}
