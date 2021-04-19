using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class VooAgendadoMapping : IEntityTypeConfiguration<VooAgendado>
    {
        public void Configure(EntityTypeBuilder<VooAgendado> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.BackgroundColor)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.TextColor)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            // RELATIONSHIP
            builder.HasOne(x => x.Aeronave)
                .WithMany(x => x.VoosAgendados)
                .HasForeignKey(x => x.AeronaveId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany(x => x.VoosAgendados)
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Voos_Agendados");
        }
    }
}
