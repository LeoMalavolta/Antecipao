using Antecipacao.Domain;
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

        public async Task<Empresa?> ObterEmpresaComCarrinho(Guid id)
        {
            return await _context.Empresas
                                 .Include(e => e.Faturamentos)
                                 .Include(e => e.Carrinhos
                                     .Where(c => c.DataAntecipacao == null)) 
                                     .ThenInclude(c => c.NotasFiscais)
                                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<decimal> ObterLimite(Guid id)
        {
            return await _context.Empresas
                .Where(e => e.Id == id)
                .Select(e => e.Limite)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EmpresaJaCadastrada(string cnpj)
        {
            var cnpjLimpo = Utils.RemoverNaoNumericos(cnpj);

            return await _context.Empresas
                .AnyAsync(c => c.Cnpj == cnpjLimpo && c.DataExclusao != null);
        }
    }
}
