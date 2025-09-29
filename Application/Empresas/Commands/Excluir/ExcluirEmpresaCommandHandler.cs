using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.Empresas;
using MediatR;
using System.Net;

namespace Antecipacao.Application.Empresas.Commands.Excluir
{
    public class ExcluirEmpresaCommandHandler : IRequestHandler<ExcluirEmpresaCommand, DomainResponse<bool>>
    {
        public readonly IEmpresaWriteRepository _repository;

        public ExcluirEmpresaCommandHandler(IEmpresaWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(ExcluirEmpresaCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel excluir a Empresa!", HttpStatusCode.BadRequest);

            var empresa = await _repository.GetById(request.id);
            if (empresa is null)
                return DomainResponse<bool>.Falied("Não foi possivel excluir a Empresa!", HttpStatusCode.NotFound);

            empresa.Excluir();

            var result = await _repository.Update(empresa);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel excluir a Empresa!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Empresa excluida com sucesso!", HttpStatusCode.NoContent);
        }
    }
}
