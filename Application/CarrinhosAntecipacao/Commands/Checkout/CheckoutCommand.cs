using Antecipacao.Domain.Base;
using MediatR;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.Checkout
{
    public record CheckoutCommand(
        Guid id,
        Guid idEmpresa) : IRequest<DomainResponse<bool>>;
}