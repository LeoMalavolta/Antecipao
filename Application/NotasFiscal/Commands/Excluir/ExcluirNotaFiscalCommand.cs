using BuildingBlocks.Core.Domain;
using MediatR;

namespace Antecipacao.Application.NotasFiscal.Commands.Excluir
{
    public record ExcluirNotaFiscalCommand(Guid id) : IRequest<DomainResponse<bool>>;

}
