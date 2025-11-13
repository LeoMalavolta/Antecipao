using BuildingBlocks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Antecipacao.Infrastructure.Data.OnModelCreating
{
    public class FaturamentoMensalConfiguration : IEntityTypeConfiguration<FaturamentoMensal>
    {
        public void Configure(EntityTypeBuilder<FaturamentoMensal> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(f => f.Periodo)
                .IsRequired();

            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Faturamentos)
                .HasForeignKey(f => f.IdEmpresa);
        }
    }
}