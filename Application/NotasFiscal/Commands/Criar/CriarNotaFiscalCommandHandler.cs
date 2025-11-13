using Antecipacao.Domain.Interfaces.NotasFiscal;
using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Entities;
using MediatR;
using System.Net;

namespace Antecipacao.Application.NotasFiscal.Commands.Criar
{
    public class CriarNotaFiscalCommandHandler : IRequestHandler<CriarNotaFiscalCommand, DomainResponse<bool>>
    {
        public readonly INotaFiscalWriteRepository _repository;

        public CriarNotaFiscalCommandHandler(INotaFiscalWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(CriarNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            var notaFiscal = new NotaFiscal(request.idEmpresa, request.idCarrinho, request.numero, request.valor, request.dataVencimento);

            var result = await _repository.Create(notaFiscal);
            if (!result)
                return DomainResponse<bool>.Falied("Erro ao criar Nota Fiscal!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Nota Fiscal criada com sucesso!", HttpStatusCode.Created);
        }
    }
}
