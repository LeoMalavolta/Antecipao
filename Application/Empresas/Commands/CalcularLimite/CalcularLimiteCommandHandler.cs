using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.Empresas;
using MediatR;
using System.Net;

namespace Antecipacao.Application.Empresas.Commands.CalcularLimite
{
   public class CalcularLimiteCommandHandler : IRequestHandler<CalcularLimiteCommand, DomainResponse<bool>>
    {
        public readonly IEmpresaWriteRepository _repository;

        public CalcularLimiteCommandHandler(IEmpresaWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(CalcularLimiteCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel calcular a novo Limite de crédito!", HttpStatusCode.BadRequest);

            var empresa = await _repository.GetById(request.id);
            if (empresa is null)
                return DomainResponse<bool>.Falied("Não foi possivel calcular a novo Limite de crédito!", HttpStatusCode.BadRequest);

            empresa.CalcularLimite();

            var result = await _repository.Update(empresa);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel calcular a novo Limite de crédito!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Limite de crédito calculado com sucesso!", HttpStatusCode.NoContent);
        }
    }
}
