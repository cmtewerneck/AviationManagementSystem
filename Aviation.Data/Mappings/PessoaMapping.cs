using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.EstadoCivil)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Telefone)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Email)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnType("varchar(14)");

            builder.ToTable("Pessoas");
        }
    }
}
