using AviationManagementApi.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationManagementApi.Data.Mappings
{
    public class ItemOrdemServicoMapping : IEntityTypeConfiguration<ItemOrdemServico>
    {
        public void Configure(EntityTypeBuilder<ItemOrdemServico> builder)
        {
            // RELATIONSHIP
            builder.HasOne(f => f.OrdemServico)
                 .WithMany(p => p.Itens)
                 .HasForeignKey(p => p.OrdemServicoId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired();

            builder.HasOne(f => f.Servico)
                 .WithMany(p => p.Itens)
                 .HasForeignKey(p => p.ServicoId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired();

            builder.ToTable("Itens_OrdensServico");
        }
    }
}
