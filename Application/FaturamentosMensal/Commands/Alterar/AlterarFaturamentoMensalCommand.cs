using Antecipacao.Domain.Base;
using MediatR;


namespace Antecipacao.Application.FaturamentosMensal.Commands.Alterar
{
    public record AlterarFaturamentoMensalCommand(
        Guid id,
        decimal valor,
        DateTime periodo) : IRequest<DomainResponse<bool>>;
}
