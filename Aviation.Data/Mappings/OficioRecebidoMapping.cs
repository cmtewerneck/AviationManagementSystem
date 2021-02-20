using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class OficioRecebidoMapping : IEntityTypeConfiguration<OficioRecebido>
    {
        public void Configure(EntityTypeBuilder<OficioRecebido> builder)
        {
            builder.Property(p => p.Numeracao)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Assunto)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Remetente)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.ToTable("Oficios_Recebidos");
        }
    }
}
