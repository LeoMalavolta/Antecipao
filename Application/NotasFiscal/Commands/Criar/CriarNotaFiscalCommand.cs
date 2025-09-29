using Antecipacao.Domain.Base;
using MediatR;

namespace Antecipacao.Application.NotasFiscal.Commands.Criar
{
    public record CriarNotaFiscalCommand(
        Guid? idCarrinho,
        string numero,
        decimal valor,
        DateTime dataVencimento) : IRequest<DomainResponse<bool>>;
}