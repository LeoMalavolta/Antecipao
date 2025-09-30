using Antecipacao.Application.NotasFiscal.Commands.Alterar;
using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.FaturamentosMensal;
using Antecipacao.Domain.Interfaces.NotasFiscal;
using MediatR;
using System.Net;

namespace Antecipacao.Application.FaturamentosMensal.Commands.Alterar
{
    public class AlterarFaturamentoMensalCommandHandler : IRequestHandler<AlterarFaturamentoMensalCommand, DomainResponse<bool>>
    {
        public readonly IFaturamentoMensalWriteRepository _repository;

        public AlterarFaturamentoMensalCommandHandler(IFaturamentoMensalWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(AlterarFaturamentoMensalCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel alterar a Faturamento Mensal, Guid Empty!", HttpStatusCode.BadRequest);

            var faturamento = await _repository.GetById(request.id);
            if (faturamento is null)
                return DomainResponse<bool>.Falied("O Faturamento não foi encontrado!", HttpStatusCode.NotFound);

            faturamento.AlterarValor(request.valor);
            faturamento.AlterarPeriodo(request.periodo);

            var result = await _repository.Update(faturamento);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel alterar o Faturamento!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Faturamento Mensal alterado com sucesso!", HttpStatusCode.NoContent);
        }
    }
}
