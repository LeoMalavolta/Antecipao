using Antecipacao.Domain.Entities;

namespace Antecipacao.Application.Empresas.Dto
{
    public class CarrinhoAntecipacaoDto
    {
        public decimal ValorTotalBruto { get; set; }
        public decimal ValorTotalLiquido { get; set; }
        public IEnumerable<NotaFiscalDto> NotasFiscais { get; set; }
        public bool Antecipado { get; set; }
        public DateTime? DataAntecipacao { get; set; }
    }
}
