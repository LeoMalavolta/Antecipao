using Antecipacao.Application.CarrinhosAntecipacao.Dto;
using BuildingBlocks.Core.Domain;
using MediatR;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.Checkout
{
    public record CheckoutCommand(
        Guid id,
        Guid idEmpresa) : IRequest<DomainResponse<CheckoutDto>>;
}