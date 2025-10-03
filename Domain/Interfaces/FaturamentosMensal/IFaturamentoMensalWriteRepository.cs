using Antecipacao.Domain.Entities;

namespace Antecipacao.Domain.Interfaces.FaturamentosMensal
{
    public interface IFaturamentoMensalWriteRepository : IWriteRepository<FaturamentoMensal>
    {
        Task<bool> PossuiFaturamentoNoPeriodo(DateTime dataFaturamento);
    }
}
