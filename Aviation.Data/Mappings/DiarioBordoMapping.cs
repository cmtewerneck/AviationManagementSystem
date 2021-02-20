using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class DiarioBordoMapping : IEntityTypeConfiguration<DiarioBordo>
    {
        public void Configure(EntityTypeBuilder<DiarioBordo> builder)
        {
            builder.Property(p => p.Base)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.De)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("varchar(4)");

            builder.Property(p => p.Para)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("varchar(4)");

            builder.Property(p => p.PreVooResponsavel)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.PosVooResponsavel)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Observacoes)
               .HasMaxLength(300)
               .HasColumnType("varchar(300)");

            builder.Property(p => p.Discrepancias)
               .HasMaxLength(300)
               .HasColumnType("varchar(300)");

            builder.Property(p => p.AcoesCorretivas)
               .HasMaxLength(300)
               .HasColumnType("varchar(300)");

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.DiariosBordo)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Comandante)
                .WithMany(x => x.DiariosBordoComandante)
                .HasForeignKey(x => x.ComandanteId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Copiloto)
                .WithMany(x => x.DiariosBordoCopiloto)
                .HasForeignKey(x => x.CopilotoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.MecanicoResponsavel)
                .WithMany(x => x.DiariosBordoMecanico)
                .HasForeignKey(x => x.MecanicoResponsavelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Diarios_Bordo");
        }
    }
}
