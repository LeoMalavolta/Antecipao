using BuildingBlocks.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Antecipacao.Infrastructure.Data.OnModelCreating
{
    public class CarrinhoAntecipacaoConfiguration : IEntityTypeConfiguration<CarrinhoAntecipacao>
    {
        public void Configure(EntityTypeBuilder<CarrinhoAntecipacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ValorTotalBruto)
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.ValorTotalLiquido)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(c => c.Empresa)
                .WithMany(e => e.Carrinhos)
                .HasForeignKey(c => c.IdEmpresa);

        }
    }

}
