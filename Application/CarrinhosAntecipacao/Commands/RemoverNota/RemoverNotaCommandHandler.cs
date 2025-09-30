using Antecipacao.Application.CarrinhosAntecipacao.Commands.AdicionarNota;
using Antecipacao.Domain.Base;
using Antecipacao.Domain.Entities;
using Antecipacao.Domain.Interfaces.CarrinhosAntecipacao;
using Antecipacao.Domain.Interfaces.Empresas;
using Antecipacao.Domain.Interfaces.NotasFiscal;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.RemoverNota
{
    public class AdicionarNotaCommandHandler : IRequestHandler<AdicionarNotaCommand, DomainResponse<bool>>
    {
        public readonly ICarrinhoAntecipacaoWriteRepository _repository;

        public AdicionarNotaCommandHandler(ICarrinhoAntecipacaoWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<DomainResponse<bool>> Handle(AdicionarNotaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.idNota == Guid.Empty)
                    return DomainResponse<bool>.Falied("Não foi possivel alterar o remover Nota Fiscal!", HttpStatusCode.BadRequest);

                var carrinho = await _repository.ObterCarrinhoComNotas(request.idEmpresa);
                if (carrinho is null)
                    return DomainResponse<bool>.Falied("Não foi possivel encontrar o Carrinho!", HttpStatusCode.BadRequest);

                carrinho.RemoverNota(request.idNota);

                var result = await _repository.Update(carrinho);
                if (!result)
                    return DomainResponse<bool>.Falied("Não foi possível remover Nota Fiscal.", HttpStatusCode.BadRequest);

                return DomainResponse<bool>.Ok(true, "Nota removida com sucesso.");
            }
            catch (Exception ex)
            {
                return DomainResponse<bool>.Falied($"Não foi possivel remover Nota Fiscal! {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }
    }
}
