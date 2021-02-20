using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class OficioEmitidoMapping : IEntityTypeConfiguration<OficioEmitido>
    {
        public void Configure(EntityTypeBuilder<OficioEmitido> builder)
        {
            builder.Property(p => p.Numeracao)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Mensagem)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Responsavel)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Destinatario)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Assunto)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.ToTable("Oficios_Emitidos");
        }
    }
}
