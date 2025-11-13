using BuildingBlocks.Core.Entities;

namespace Antecipacao.Domain.Interfaces.CarrinhosAntecipacao
{
    public interface ICarrinhoAntecipacaoWriteRepository : IWriteRepository<CarrinhoAntecipacao>
    {
        Task<CarrinhoAntecipacao> ObterCarrinhoComNotas(Guid id);
    }
}
