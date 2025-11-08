using Antecipacao.Domain.Base;
using Antecipacao.Domain.Entities;
using Antecipacao.Domain.Interfaces.CarrinhosAntecipacao;
using Antecipacao.Domain.Interfaces.Empresas;
using Antecipacao.Domain.Interfaces.NotasFiscal;
using MediatR;
using System.Net;

namespace Antecipacao.Application.CarrinhosAntecipacao.Commands.AdicionarNota
{
    public class AdicionarNotaCommandHandler : IRequestHandler<AdicionarNotaCommand, DomainResponse<bool>>
    {
        public readonly ICarrinhoAntecipacaoWriteRepository _repository;
        public readonly INotaFiscalWriteRepository _notaRepository;
        public readonly IEmpresaWriteRepository _empresaRepository; 
        public readonly AdicionarNotaCommandValidation _validator; 

        public AdicionarNotaCommandHandler(ICarrinhoAntecipacaoWriteRepository repository, INotaFiscalWriteRepository notaRepository, IEmpresaWriteRepository empresaRepository, AdicionarNotaCommandValidation validator)
        {
            _repository = repository;
            _notaRepository = notaRepository;
            _empresaRepository = empresaRepository;
            _validator = validator;
        }

        public async Task<DomainResponse<bool>> Handle(AdicionarNotaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                    return DomainResponse<bool>.Falied($"Não foi possivel adicionar Nota Fiscal! {errors}", HttpStatusCode.BadRequest);
                }

                var nota = await _notaRepository.GetById(request.idNota);
                if (nota is null)
                    return DomainResponse<bool>.Falied("Não foi possivel encontrar Nota Fiscal!", HttpStatusCode.BadRequest);

                var limiteEmpresa = await _empresaRepository.ObterLimite(request.idEmpresa);

                var carrinho = await _repository.ObterCarrinhoComNotas(request.idEmpresa);
                if (carrinho is null)
                {
                    carrinho = new CarrinhoAntecipacao(request.idEmpresa);
                    carrinho.AdicionarNota(nota, limiteEmpresa);

                    var result = await _repository.Create(carrinho);
                    if (!result)
                        return DomainResponse<bool>.Falied("Não foi possível adicionar Nota.", HttpStatusCode.BadRequest);
                }
                else
                {
                    carrinho.AdicionarNota(nota, limiteEmpresa);
                    var result = await _repository.Update(carrinho);
                    if (!result)
                        return DomainResponse<bool>.Falied("Não foi possível adicionar Nota.", HttpStatusCode.BadRequest);
                }

                return DomainResponse<bool>.Ok(true, "Nota adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                return DomainResponse<bool>.Falied($"Não foi possivel adicionar Nota Fiscal! {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
    }
}
