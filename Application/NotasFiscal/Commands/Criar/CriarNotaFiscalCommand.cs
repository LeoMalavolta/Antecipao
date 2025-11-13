using BuildingBlocks.Core.Domain;
using MediatR;

namespace Antecipacao.Application.NotasFiscal.Commands.Criar
{
    public record CriarNotaFiscalCommand(
        Guid idEmpresa,
        Guid? idCarrinho,
        string numero,
        decimal valor,
        DateTime dataVencimento) : IRequest<DomainResponse<bool>>;
}