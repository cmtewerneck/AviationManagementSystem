using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class VeiculoGastoMapping : IEntityTypeConfiguration<VeiculoGasto>
    {
        public void Configure(EntityTypeBuilder<VeiculoGasto> builder)
        {
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            // RELATIONSHIP
            builder.HasOne(x => x.Veiculo)
                .WithMany(x => x.VeiculoGastos)
                .HasForeignKey(x => x.VeiculoId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Motorista)
                .WithMany(x => x.VeiculosGastos)
                .HasForeignKey(x => x.MotoristaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Veiculo_Gastos");
        }
    }
}
