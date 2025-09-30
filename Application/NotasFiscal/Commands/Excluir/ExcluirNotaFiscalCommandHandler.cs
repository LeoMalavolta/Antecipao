using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.NotasFiscal;
using MediatR;
using System.Net;

namespace Antecipacao.Application.NotasFiscal.Commands.Excluir
{
    public class ExcluirNotaFiscalCommandHandler : IRequestHandler<ExcluirNotaFiscalCommand, DomainResponse<bool>>
    {
        public readonly INotaFiscalWriteRepository _repository;

        public ExcluirNotaFiscalCommandHandler(INotaFiscalWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(ExcluirNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel excluir a Nota Fiscal!", HttpStatusCode.BadRequest);

            var notaFiscal = await _repository.GetById(request.id);
            if (notaFiscal is null)
                return DomainResponse<bool>.Falied("Não foi possivel excluir a Nota Fiscal!", HttpStatusCode.NotFound);

            notaFiscal.Excluir();

            var result = await _repository.Update(notaFiscal);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel excluir a Nota Fiscal!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Nota Fiscal excluida com sucesso!", HttpStatusCode.NoContent);
        }
    }
}
