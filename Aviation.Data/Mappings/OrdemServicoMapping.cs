using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class OrdemServicoMapping : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.Property(p => p.NumeroOrdem)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.HasIndex(x => x.NumeroOrdem).IsUnique();

            builder.Property(p => p.Tipo)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Ttsn)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.TcsnPousos)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.TtsnMotor)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.TcsnCiclos)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.RequisicaoMateriais)
                .HasMaxLength(300)
                .HasColumnType("varchar(300)");

            builder.Property(p => p.RealizadoPor)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.RealizadoPorAnac)
                .HasMaxLength(6)
                .HasColumnType("varchar(6)");

            builder.Property(p => p.InspecionadoPor)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.InspecionadoPorAnac)
                .HasMaxLength(6)
                .HasColumnType("varchar(6)");

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.OrdensServico)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Ordens_Servico");
        }
    }
}