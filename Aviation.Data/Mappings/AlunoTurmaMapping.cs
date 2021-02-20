using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class AlunoTurmaMapping : IEntityTypeConfiguration<AlunoTurma>
    {
        public void Configure(EntityTypeBuilder<AlunoTurma> builder)
        {
            // RELATIONSHIP
            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.AlunosTurmas)
                .HasForeignKey(x => x.AlunoId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.AlunosTurmas)
                .HasForeignKey(x => x.TurmaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Alunos_Turmas");
        }
    }
}
