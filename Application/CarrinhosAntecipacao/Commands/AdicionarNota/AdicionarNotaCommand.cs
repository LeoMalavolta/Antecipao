using Antecipacao.Domain.Base;
using MediatR;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.AdicionarNota
{
     public record AdicionarNotaCommand(Guid idEmpresa, Guid idNota) : IRequest<DomainResponse<bool>>;
}