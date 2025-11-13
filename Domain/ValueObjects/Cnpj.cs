

using BuildingBlocks.Exceptions.Domain;

namespace Antecipacao.Domain.ValueObjects
{
    public class CNPJ
    {
        public string Numero { get; private set; }

        protected CNPJ() { } 

        public CNPJ(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new DomainException("CNPJ não pode ser vazio.");

            numero = LimparFormato(numero);

            if (!EhValido(numero))
                throw new DomainException("CNPJ inválido.");

            Numero = numero;
        }

        private static string LimparFormato(string cnpj)
        {
            return new string(cnpj.Where(char.IsDigit).ToArray());
        }

        public static bool EhValido(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            // Rejeita CNPJs com todos dígitos iguais
            if (new string(cnpj[0], 14) == cnpj)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public override string ToString()
        {
            return Convert.ToUInt64(Numero).ToString(@"00\.000\.000\/0000\-00");
        }

        public override bool Equals(object obj)
        {
            if (obj is not CNPJ other) return false;
            return Numero == other.Numero;
        }

        public override int GetHashCode() => Numero.GetHashCode();
    }
}
