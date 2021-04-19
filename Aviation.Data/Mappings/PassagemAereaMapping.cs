using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class PassagemAereaMapping : IEntityTypeConfiguration<PassagemAerea>
    {
        public void Configure(EntityTypeBuilder<PassagemAerea> builder)
        {
            builder.Property(p => p.Empresa)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Origem)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Destino)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.FormaPagamento)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Assento)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Localizador)
            .HasMaxLength(30)
            .HasColumnType("varchar(30)");

            builder.ToTable("Passagens_Aereas");
        }
    }
}
