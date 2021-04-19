using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class MotorMapping : IEntityTypeConfiguration<AeronaveMotor>
    {
        public void Configure(EntityTypeBuilder<AeronaveMotor> builder)
        {
            builder.Property(p => p.Fabricante)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Modelo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.NumeroSerie)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.AeronaveMotores)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Aeronaves_Motores");
        }
    }
}
