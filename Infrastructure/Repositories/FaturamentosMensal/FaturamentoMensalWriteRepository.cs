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
            await _context.FaturamentosMensal.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(FaturamentoMensal entity)
        {
            _context.FaturamentosMensal.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _context.FaturamentosMensal.Where(e => e.Id == id)
                                       .ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<FaturamentoMensal> GetById(Guid id)
        {
            return await _context.FaturamentosMensal.FindAsync(id);
        }
    }
}
