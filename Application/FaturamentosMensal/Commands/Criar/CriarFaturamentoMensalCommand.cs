using Antecipacao.Domain.Base;
using MediatR;

namespace Antecipacao.Application.FaturamentosMensal.Commands.Criar
{
    public record CriarFaturamentoMensalCommand(
        Guid idEmpresa,
        decimal valor,
        DateTime periodo) : IRequest<DomainResponse<bool>>;
}
