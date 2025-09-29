using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.Empresas;
using MediatR;
using System.Net;

namespace Antecipacao.Application.Empresas.Commands.Alterar
{
    public class AlterarEmpresaCommandHandler : IRequestHandler<AlterarEmpresaCommand, DomainResponse<bool>>
    {
        public readonly IEmpresaWriteRepository _repository;

        public AlterarEmpresaCommandHandler(IEmpresaWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(AlterarEmpresaCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel alterar a Empresa!", HttpStatusCode.NoContent);

            var empresa = await _repository.GetById(request.id);
            if (empresa is null)
                return DomainResponse<bool>.Falied("Não foi possivel alterar a Empresa!", HttpStatusCode.NotFound);

            empresa.AlterarNome(request.nome);
            empresa.AlterarCnpj(request.cnpj);
            empresa.AlterarRamoEmpresa(request.ramo);

            var result = await _repository.Update(empresa);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel alterar a Empresa!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Empresa excluida com sucesso!", HttpStatusCode.Created);
        }
    }
}
