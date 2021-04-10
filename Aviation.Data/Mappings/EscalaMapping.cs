using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class EscalaMapping : IEntityTypeConfiguration<Escala>
    {
        public void Configure(EntityTypeBuilder<Escala> builder)
        {
            // RELATIONSHIP
            builder.HasOne(x => x.Tripulante)
                .WithMany(x => x.Escalas)
                .HasForeignKey(x => x.TripulanteId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Escalas");
        }
    }
}
