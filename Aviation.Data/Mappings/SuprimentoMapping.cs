using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class SuprimentoMapping : IEntityTypeConfiguration<Suprimento>
    {
        public void Configure(EntityTypeBuilder<Suprimento> builder)
        {
            builder.Property(p => p.Codigo)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.PartNumber)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Nomenclatura)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

            builder.Property(p => p.Localizacao)
               .HasMaxLength(30)
               .HasColumnType("varchar(30)");

            builder.Property(p => p.PartNumberAlternativo)
               .HasMaxLength(30)
               .HasColumnType("varchar(30)");

            builder.Property(p => p.Aplicacao)
               .HasMaxLength(20)
               .HasColumnType("varchar(20)");

            builder.Property(p => p.Capitulo)
               .HasMaxLength(20)
               .HasColumnType("varchar(20)");

            builder.Property(p => p.SerialNumber)
               .HasMaxLength(30)
               .HasColumnType("varchar(30)");

            builder.Property(p => p.Doc)
               .HasMaxLength(20)
               .HasColumnType("varchar(20)");

            builder.ToTable("Suprimentos");
        }
    }
}
