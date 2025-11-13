using BuildingBlocks.Core.Domain;
using MediatR;

namespace Antecipacao.Application.Empresas.Commands.Alterar
{
    public record AlterarEmpresaCommand(
        Guid id,
        string nome,
        string cnpj,
        int ramo) : IRequest<DomainResponse<bool>>;
}
