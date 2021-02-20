using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class AeronaveMapping : IEntityTypeConfiguration<Aeronave>
    {
        public void Configure(EntityTypeBuilder<Aeronave> builder)
        {
            builder.Property(c => c.Matricula)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("varchar(5)");

            builder.HasIndex(c => c.Matricula).IsUnique();

            builder.Property(c => c.Fabricante)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Categoria)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Modelo)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(c => c.NumeroSerie)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Motor)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(c => c.ModeloMotor)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(c => c.NumeroSerieMotor)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.ToTable("Aeronaves");
        }
    }
}
