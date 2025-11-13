using BuildingBlocks.Core.Domain;
using MediatR;

namespace Antecipacao.Application.FaturamentosMensal.Commands.Excluir
{
    public record ExcluirFaturamentoMensalCommand(Guid id) : IRequest<DomainResponse<bool>>;

}
