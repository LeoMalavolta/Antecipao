using Antecipacao.Domain.Base;
using MediatR;

namespace Antecipacao.Application.Empresas.Commands.Excluir
{
    public record ExcluirEmpresaCommand(Guid id) : IRequest<DomainResponse<bool>>;
}
