using Antecipacao.Domain.Base;
using MediatR;

namespace Antecipacao.Application.Empresas.Commands.Criar
{
    public record CriarEmpresaCommand(
        string nome,
        string cnpj,
        int ramo) : IRequest<DomainResponse<bool>>;
}
