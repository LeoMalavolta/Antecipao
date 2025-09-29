using Antecipacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Antecipacao.Infrastructure.Data
{
    public class AntecipacaoDeRecebiveisDbContext : DbContext
    {
        public AntecipacaoDeRecebiveisDbContext(DbContextOptions<AntecipacaoDeRecebiveisDbContext> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<FaturamentoMensal> FaturamentosMensal { get; set; }
        public DbSet<CarrinhoAntecipacao> CarrinhosAntecipacao { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }

    }
}

