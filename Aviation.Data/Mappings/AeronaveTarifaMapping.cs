using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class AeronaveTarifaMapping : IEntityTypeConfiguration<AeronaveTarifa>
    {
        public void Configure(EntityTypeBuilder<AeronaveTarifa> builder)
        {
            builder.Property(p => p.Numeracao)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.AeronaveTarifas)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Aeronaves_Tarifas");
        }
    }
}
