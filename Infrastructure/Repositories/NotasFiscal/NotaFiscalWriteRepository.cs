using Antecipacao.Domain.Entities;
using Antecipacao.Domain.Interfaces.NotasFiscal;
using Antecipacao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Antecipacao.Infrastructure.Repositories.NotasFiscal
{
    public class NotaFiscalWriteRepository : INotaFiscalWriteRepository
    {
        private readonly AntecipacaoDeRecebiveisDbContext _context;

        public NotaFiscalWriteRepository(AntecipacaoDeRecebiveisDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(NotaFiscal entity)
        {
            try
            {
                await _context.NotasFiscais.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(NotaFiscal entity)
        {
            _context.NotasFiscais.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _context.NotasFiscais.Where(e => e.Id == id)
                           .ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<NotaFiscal> GetById(Guid id)
        {
            return await _context.NotasFiscais.FindAsync(id);
        }
    }
}
