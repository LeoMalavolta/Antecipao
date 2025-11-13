using Antecipacao.Domain.Interfaces.Empresas;
using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Entities;
using MediatR;
using System.Net;

namespace Antecipacao.Application.Empresas.Commands.Criar
{
    public class CriarEmpresaCommandHandler : IRequestHandler<CriarEmpresaCommand, DomainResponse<bool>>
    {
        public readonly IEmpresaWriteRepository _repository;

        public CriarEmpresaCommandHandler(IEmpresaWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(CriarEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = new Empresa(request.nome,
                                      request.cnpj,
                                      request.faturamentoMensal,
                                      request.ramo);

            if (await _repository.EmpresaJaCadastrada(request.cnpj, empresa.Id))
                return DomainResponse<bool>.Falied("O Cnpj já está cadastrada!", HttpStatusCode.BadRequest);

            var result = await _repository.Create(empresa);
            if (!result)
                return DomainResponse<bool>.Falied("Erro ao criar Empresa!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Empresa criada com sucesso!", HttpStatusCode.Created);
        }
    }
}
