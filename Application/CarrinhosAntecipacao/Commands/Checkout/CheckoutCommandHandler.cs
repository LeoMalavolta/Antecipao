using Antecipacao.Domain.Base;
using Antecipacao.Domain.Interfaces.CarrinhosAntecipacao;
using Antecipacao.Domain.Interfaces.Empresas;
using MediatR;
using System.Net;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.Checkout
{
    public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, DomainResponse<bool>>
    {
        public readonly ICarrinhoAntecipacaoWriteRepository _repository;
        public readonly IEmpresaWriteRepository _empresaRepository;

        public CheckoutCommandHandler(ICarrinhoAntecipacaoWriteRepository repository, IEmpresaWriteRepository empresaRepository)
        {
            _repository = repository;
            _empresaRepository = empresaRepository;
        }

        public async Task<DomainResponse<bool>> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty || request.idEmpresa == Guid.Empty)
                return DomainResponse<bool>.Falied("Não foi possivel fazer Checkout!", HttpStatusCode.BadRequest);

            var empresa = await _empresaRepository.ObterEmpresaComCarrinho(request.id);
            var carrinhoAtivo = empresa.Carrinho.FirstOrDefault(c => c.NotasFiscais != null && c.NotasFiscais.Any());

            if (empresa is null || carrinhoAtivo is null)
                return DomainResponse<bool>.Falied("Não foi possivel fazer Checkout!", HttpStatusCode.NotFound);

            carrinhoAtivo.Checkout();

            var result = await _repository.Update(carrinhoAtivo);
            if (!result)
                return DomainResponse<bool>.Falied("Não foi possivel alterar o Carrinho Antecipação!", HttpStatusCode.BadRequest);

            return DomainResponse<bool>.Created("Carrinho Antecipação alterado com sucesso!", HttpStatusCode.NoContent);
        }
    }
}
