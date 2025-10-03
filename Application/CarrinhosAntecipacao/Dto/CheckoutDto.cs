
using Antecipacao.Application.NotasFiscal.Dto;

namespace Antecipacao.Application.CarrinhosAntecipacao.Dto
{
    public class CheckoutDto
    {
        public string empresa { get; set; }
        public string cnpj { get; set; }
        public decimal limite { get; set; }
        public IEnumerable<NotaFiscalDto> notas_fiscais { get; set; }
        public decimal total_liquido { get; set; }
        public decimal total_bruto { get; set; }
    }
}
