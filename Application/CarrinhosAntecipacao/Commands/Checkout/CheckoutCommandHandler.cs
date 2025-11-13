using Antecipacao.Application.CarrinhosAntecipacao.Dto;
using Antecipacao.Application.NotasFiscal.Dto;
using Antecipacao.Domain.Interfaces.CarrinhosAntecipacao;
using Antecipacao.Domain.Interfaces.Empresas;
using BuildingBlocks.Core.Domain;
using BuildingBlocks.Core.Entities;
using MediatR;
using System.Net;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.Checkout
{
    public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, DomainResponse<CheckoutDto>>
    {
        public readonly ICarrinhoAntecipacaoWriteRepository _repository;
        public readonly IEmpresaWriteRepository _empresaRepository;

        public CheckoutCommandHandler(ICarrinhoAntecipacaoWriteRepository repository, IEmpresaWriteRepository empresaRepository)
        {
            _repository = repository;
            _empresaRepository = empresaRepository;
        }

        public async Task<DomainResponse<CheckoutDto>> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            if (request.id == Guid.Empty || request.idEmpresa == Guid.Empty)
                return DomainResponse<CheckoutDto>.Falied("Não foi possivel fazer Checkout!", HttpStatusCode.BadRequest);

            var empresa = await _empresaRepository.ObterEmpresaComCarrinho(request.idEmpresa);
            var carrinho = empresa.Carrinhos.FirstOrDefault(c => c.DataAntecipacao == null);

            if (carrinho is null || !carrinho.NotasFiscais.Any())
                return DomainResponse<CheckoutDto>.Falied("Não existem notas no carrinho!", HttpStatusCode.NotFound);

            var checkoutEmpresa = Checkout(carrinho);
            carrinho.Checkout();

            var result = await _repository.Update(carrinho);
            if (!result)
                return DomainResponse<CheckoutDto>.Falied("Não foi possivel fazer o Checkout!", HttpStatusCode.BadRequest);

            return DomainResponse<CheckoutDto>.Ok(checkoutEmpresa, "Checkout feito com sucesso!", HttpStatusCode.OK);
        }

        private CheckoutDto Checkout(CarrinhoAntecipacao carrinho)
        {
            var resultadoNotas = new List<NotaFiscalDto>();
            decimal valorTotalLiquido = 0m;
            var dataAtual = DateTime.UtcNow;
            var taxa = 0.0465m;


            foreach (var nota in carrinho.NotasFiscais)
            {
                var prazo = Math.Abs((nota.DataVencimento - dataAtual).Days);

                // Valor líquido = valor presente
                var valorLiquido = nota.ValorBruto /
                    (decimal)Math.Pow((double)(1 + taxa), (double)prazo / 30);

                var notaDto = new NotaFiscalDto
                {
                    numero = nota.Numero,
                    valor_bruto = Math.Round(nota.ValorBruto, 2),
                    valor_liquido = Math.Round(valorLiquido, 2)
                };

                resultadoNotas.Add(notaDto);
                valorTotalLiquido += valorLiquido;
            }

            return new CheckoutDto
            {
                empresa = carrinho.Empresa.Nome,
                cnpj = carrinho.Empresa.Cnpj,
                limite = carrinho.Empresa.Limite,
                notas_fiscais = resultadoNotas,
                total_bruto = Math.Round(carrinho.NotasFiscais.Sum(c => c.ValorBruto), 2),
                total_liquido = Math.Round(valorTotalLiquido, 2)
            };
        }
    }
}
