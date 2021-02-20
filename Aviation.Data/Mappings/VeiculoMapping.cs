using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.Property(p => p.Placa)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(p => p.UfPlaca)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(2)");

            builder.Property(p => p.Modelo)
               .IsRequired()
               .HasMaxLength(30)
               .HasColumnType("varchar(30)");

            builder.Property(p => p.Renavam)
               .IsRequired()
               .HasMaxLength(30)
               .HasColumnType("varchar(30)");

            builder.ToTable("Veiculos");
        }
    }
}
