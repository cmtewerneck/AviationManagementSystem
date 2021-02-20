using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class SuprimentoMovimentacaoMapping : IEntityTypeConfiguration<SuprimentoMovimentacao>
    {
        public void Configure(EntityTypeBuilder<SuprimentoMovimentacao> builder)
        {
            // RELATIONSHIP
            builder.HasOne(x => x.Item)
                .WithMany(x => x.SuprimentosMovimentacoes)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable("Suprimento_Movimentacoes");
        }
    }
}
