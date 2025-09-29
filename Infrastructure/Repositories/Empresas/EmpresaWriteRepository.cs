using Antecipacao.Domain.Entities;
using Antecipacao.Domain.Interfaces.Empresas;
using Antecipacao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Antecipacao.Infrastructure.Repositories.Empresas
{
    public class EmpresaWriteRepository : IEmpresaWriteRepository
    {
        private readonly AntecipacaoDeRecebiveisDbContext _context;

        public EmpresaWriteRepository(AntecipacaoDeRecebiveisDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Empresa entity)
        {
            await _context.Empresas.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Empresa entity)
        {
            _context.Empresas.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            await _context.Empresas.Where(e => e.Id == id)
                                   .ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Empresa> GetById(Guid id)
        {
            return await _context.Empresas.FindAsync(id);
        }
    }
}
