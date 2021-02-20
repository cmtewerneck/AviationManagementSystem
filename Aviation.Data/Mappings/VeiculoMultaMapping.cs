using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class VeiculoMultaMapping : IEntityTypeConfiguration<VeiculoMulta>
    {
        public void Configure(EntityTypeBuilder<VeiculoMulta> builder)
        {
            builder.Property(p => p.AutoInfracao)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Responsavel)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Classificacao)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            // RELATIONSHIP
            builder.HasOne(x => x.Veiculo)
                .WithMany(x => x.VeiculoMultas)
                .HasForeignKey(x => x.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Veiculo_Multas");
        }
    }
}
