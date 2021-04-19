using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class DiariaTripulanteMapping : IEntityTypeConfiguration<DiariaTripulante>
    {
        public void Configure(EntityTypeBuilder<DiariaTripulante> builder)
        {
            builder.Property(p => p.Finalidade)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            builder.Property(p => p.FormaPagamento)
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            // RELATIONSHIP
            builder.HasOne(x => x.Tripulante)
                .WithMany(x => x.DiariasTripulante)
                .HasForeignKey(x => x.TripulanteId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Diarias_Tripulantes");
        }
    }
}
