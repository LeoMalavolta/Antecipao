using Antecipacao.Domain.Entities;
using Antecipacao.Domain.Interfaces.FaturamentosMensal;
using Antecipacao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Antecipacao.Infrastructure.Repositories.FaturamentosMensal
{
    public class FaturamentoMensalWriteRepository : IFaturamentoMensalWriteRepository
    {
        private readonly AntecipacaoDeRecebiveisDbContext _context;

        public FaturamentoMensalWriteRepository(AntecipacaoDeRecebiveisDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(FaturamentoMensal entity)
        {
            try
            {
                await _context.FaturamentosMensal.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(FaturamentoMensal entity)
        {
            _context.FaturamentosMensal.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _context.FaturamentosMensal.Where(e => e.Id == id)
                                       .ExecuteDeleteAsync() > 0;
        }

        public async Task<FaturamentoMensal> GetById(Guid id)
        {
            return await _context.FaturamentosMensal.FindAsync(id);
        }

        public async Task<bool> PossuiFaturamentoNoPeriodo(DateTime dataFaturamento)
        {
            return await _context.FaturamentosMensal
                .AnyAsync(f => f.Periodo.Month == dataFaturamento.Month
                            && f.Periodo.Year == dataFaturamento.Year
                            && f.DataExclusao == null);
        }
    }
}
