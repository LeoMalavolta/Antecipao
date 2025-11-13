using BuildingBlocks.Core.Domain;
using MediatR;

namespace Antecipacao.Application.NotasFiscal.Commands.Alterar
{
    public record AlterarNotaFiscalCommand(
        Guid id,
        string numero,
        decimal valor,
        DateTime dataVencimento) : IRequest<DomainResponse<bool>>;
}