using Antecipacao.Domain.Interfaces.CarrinhosAntecipacao;
using Antecipacao.Infrastructure.Data;
using BuildingBlocks.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Antecipacao.Infrastructure.Repositories.CarrinhosAntecipacao
{
    public class CarrinhoAntecipacaoWriteRepository : ICarrinhoAntecipacaoWriteRepository
    {
        private readonly AntecipacaoDeRecebiveisDbContext _context;

        public CarrinhoAntecipacaoWriteRepository(AntecipacaoDeRecebiveisDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(CarrinhoAntecipacao entity)
        {
            await _context.CarrinhosAntecipacao.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(CarrinhoAntecipacao entity)
        {
            _context.CarrinhosAntecipacao.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _context.CarrinhosAntecipacao.Where(e => e.Id == id)
                           .ExecuteDeleteAsync() > 0;
        }

        public async Task<CarrinhoAntecipacao> GetById(Guid id)
        {
            return await _context.CarrinhosAntecipacao.FindAsync(id);
        }

        public async Task<CarrinhoAntecipacao?> ObterCarrinhoComNotas(Guid id)
        {
            return await _context.CarrinhosAntecipacao
                                 .Include(c => c.NotasFiscais)
                                 .FirstOrDefaultAsync(c => c.IdEmpresa == id && c.DataAntecipacao == null);
        }
    }
}
