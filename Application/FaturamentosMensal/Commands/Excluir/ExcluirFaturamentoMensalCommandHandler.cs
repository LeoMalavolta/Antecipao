using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.FaturamentosMensal;
using MediatR;
using System.Net;

namespace Antecipacao.Application.FaturamentosMensal.Commands.Excluir
{
    public class ExcluirFaturamentoMensalCommandHandler : IRequestHandler<ExcluirFaturamentoMensalCommand, DomainResponse<bool>>
    {
        public readonly IFaturamentoMensalWriteRepository _repository;

        public ExcluirFaturamentoMensalCommandHandler(IFaturamentoMensalWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(ExcluirFaturamentoMensalCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel excluir o Faturamento Mensal!", HttpStatusCode.BadRequest);

            var faturamento = await _repository.GetById(request.id);
            if (faturamento is null)
                return DomainResponse<bool>.Falied("Não foi possivel excluir o Faturamento Mensal!", HttpStatusCode.NotFound);

            faturamento.Excluir();

            var result = await _repository.Update(faturamento);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel excluir o Faturamento Mensal!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Faturamento Mensal excluida com sucesso!", HttpStatusCode.NoContent);
        }
    }
}
