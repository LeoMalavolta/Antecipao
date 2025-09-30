using Antecipacao.Domain.Base;
using MediatR;

namespace Antecipacao.Application.Empresas.Commands.CalcularLimite
{
    public record CalcularLimiteCommand(
        Guid id) : IRequest<DomainResponse<bool>>;
}
