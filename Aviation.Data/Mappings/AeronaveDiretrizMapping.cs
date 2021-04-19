using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class AeronaveDiretrizMapping : IEntityTypeConfiguration<AeronaveDiretriz>
    {
        public void Configure(EntityTypeBuilder<AeronaveDiretriz> builder)
        {
            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Referencia)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(p => p.DataEfetivacao)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            builder.Property(p => p.TipoDiretriz)
                .IsRequired();

            builder.Property(p => p.Observacoes)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Status)
                .IsRequired();

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.AeronaveDiretrizes)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Aeronaves_Diretrizes");
        }
    }
}
