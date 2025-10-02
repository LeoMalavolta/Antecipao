using Antecipacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Antecipacao.Infrastructure.Data.OnModelCreating
{
    public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Numero)
                .IsRequired();

            builder.Property(n => n.ValorBruto)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(n => n.ValorLiquido)
                .HasColumnType("decimal(18,2)");

            builder.Property(n => n.DataVencimento)
                .IsRequired();

            builder.HasOne(n => n.Empresa)
                .WithMany(e => e.NotasFiscais)
                .HasForeignKey(n => n.IdEmpresa);

            builder.HasOne(n => n.Carrinho)
                .WithMany(c => c.NotasFiscais)
                .HasForeignKey(n => n.IdCarrinho);
        }
    }
}