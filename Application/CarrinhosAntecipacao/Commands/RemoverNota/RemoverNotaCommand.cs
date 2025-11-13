using BuildingBlocks.Core.Domain;
using MediatR;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.RemoverNota
{
     public record RemoverNotaCommand(Guid idEmpresa, Guid idNota) : IRequest<DomainResponse<bool>>;
}