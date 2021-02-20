using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class AbastecimentoMapping : IEntityTypeConfiguration<AeronaveAbastecimento>
    {
        public void Configure(EntityTypeBuilder<AeronaveAbastecimento> builder)
        {
            builder.Property(p => p.Local)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Cupom)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.NotaFiscal)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Fornecedora)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Responsavel)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Observacoes)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.AeronavesAbastecimentos)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Aeronaves_Abastecimentos");
        }
    }
}
