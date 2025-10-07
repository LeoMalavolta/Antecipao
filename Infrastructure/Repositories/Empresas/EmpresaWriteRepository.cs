using Antecipacao.Domain;
using Antecipacao.Domain.Entities;
using Antecipacao.Domain.Interfaces.Empresas;
using Antecipacao.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Antecipacao.Infrastructure.Repositories.Empresas
{
    public class EmpresaWriteRepository : IEmpresaWriteRepository
    {
        private readonly AntecipacaoDeRecebiveisDbContext _context;
        private readonly ILogger<EmpresaWriteRepository> _logger;

        public EmpresaWriteRepository(AntecipacaoDeRecebiveisDbContext context, ILogger<EmpresaWriteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Create(Empresa entity)
        {
            try
            {

                await _context.Empresas.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar empresa. CNPJ: {Cnpj}, Nome: {Nome}", entity.Cnpj, entity.Nome);
                throw;
            }
        }

        public async Task<bool> Update(Empresa entity)
        {
            _context.Empresas.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _context.Empresas.Where(e => e.Id == id)
                                   .ExecuteDeleteAsync() > 0;
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

        public async Task<Empresa?> ObterEmpresaComFaturamento(Guid id)
        {
            return await _context.Empresas
                                 .Include(e => e.Faturamentos)
                                 .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<decimal> ObterLimite(Guid id)
        {
            return await _context.Empresas
                .Where(e => e.Id == id)
                .Select(e => e.Limite)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EmpresaJaCadastrada(string cnpj, Guid id)
        {
            var cnpjLimpo = Utils.RemoverNaoNumericos(cnpj);

            return await _context.Empresas
                .AnyAsync(c => c.Cnpj == cnpjLimpo && c.DataExclusao == null && c.Id != id);
        }
    }
}
