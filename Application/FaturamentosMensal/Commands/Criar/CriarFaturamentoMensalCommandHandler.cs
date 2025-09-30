using Antecipacao.Domain.Base;
using Antecipacao.Domain.Entities;
using Antecipacao.Domain.Interfaces.FaturamentosMensal;
using MediatR;
using System.Net;

namespace Antecipacao.Application.FaturamentosMensal.Commands.Criar
{
    public class CriarFaturamentoMensalCommandHandler : IRequestHandler<CriarFaturamentoMensalCommand, DomainResponse<bool>>
    {
        public readonly IFaturamentoMensalWriteRepository _repository;

        public CriarFaturamentoMensalCommandHandler(IFaturamentoMensalWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(CriarFaturamentoMensalCommand request, CancellationToken cancellationToken)
        {
            var faturamento = new FaturamentoMensal(request.idEmpresa, request.valor, request.periodo);

            var result = await _repository.Create(faturamento);
            if (!result)
                return DomainResponse<bool>.Falied("Erro ao criar Faturamento Mensal!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Faturamento Mensal criada com sucesso!", HttpStatusCode.Created);
        }
    }
}
