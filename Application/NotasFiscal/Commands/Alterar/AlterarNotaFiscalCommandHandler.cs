using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.NotasFiscal;
using MediatR;
using System.Net;

namespace Antecipacao.Application.NotasFiscal.Commands.Alterar
{
    public class AlterarNotaFiscalCommandHandler : IRequestHandler<AlterarNotaFiscalCommand, DomainResponse<bool>>
    {
        public readonly INotaFiscalWriteRepository _repository;

        public AlterarNotaFiscalCommandHandler(INotaFiscalWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(AlterarNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel alterar a Nota Fiscal!", HttpStatusCode.BadRequest);

            var notaFiscal = await _repository.GetById(request.id);
            if (notaFiscal is null)
                return DomainResponse<bool>.Falied("Não foi possivel alterar a Nota Fiscal!", HttpStatusCode.NotFound);

            notaFiscal.AlterarNumero(request.numero);
            notaFiscal.AlterarValorBruto(request.valor);
            notaFiscal.AlterarDataVencimento(request.dataVencimento);

            var result = await _repository.Update(notaFiscal);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel alterar a Nota Fiscal!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Nota Fiscal alterada com sucesso!", HttpStatusCode.NoContent);
        }
    }
}
