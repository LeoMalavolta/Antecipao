using Antecipacao.Domain.Entities;
using Antecipacao.Infrastructure.Data.OnModelCreating;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new NotaFiscalConfiguration());
            modelBuilder.ApplyConfiguration(new CarrinhoAntecipacaoConfiguration());
            modelBuilder.ApplyConfiguration(new FaturamentoMensalConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

