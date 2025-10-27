using Antecipacao.Domain.Entities;
using Antecipacao.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace Antecipacao.Infrastructure.Data.OnModelCreating
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.HasIndex(e => e.Cnpj)
                .IsUnique();

            builder.Property(e => e.Limite)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.RamoEmpresa)
                .IsRequired();

            builder.HasMany(e => e.Faturamentos)
                .WithOne(f => f.Empresa)
                .HasForeignKey(f => f.IdEmpresa);

            builder.HasMany(e => e.NotasFiscais)
                .WithOne(n => n.Empresa)
                .HasForeignKey(n => n.IdEmpresa);

            builder.HasMany(e => e.Carrinhos)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.IdEmpresa);
        }
    }
}