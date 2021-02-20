using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.Property(p => p.Codigo)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar(30)");

            // RELATIONSHIP
            builder.HasOne(x => x.Curso)
                .WithMany(x => x.Turmas)
                .HasForeignKey(x => x.CursoId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Turmas");
        }
    }
}
