using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("int").IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasColumnType("int").IsRequired();
            
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasColumnType("varchar").IsRequired();
            builder.Property(x => x.PrecoCusto).HasColumnName("precoCusto").HasColumnType("int").IsRequired();
            builder.Property(x => x.PrecoVenda).HasColumnName("precoVenda").HasColumnType("int").IsRequired();
            builder.Property(x => x.Tipo).HasColumnName("tipo").HasColumnType("int").IsRequired();

            builder.Property(x => x.CategoriaId).HasColumnName("categoriaId").HasColumnType("int").IsRequired();
            builder.Property(x => x.FornecedorId).HasColumnName("fornecedorId").HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Fornecedor).WithMany().HasForeignKey(x => x.FornecedorId).IsRequired();
            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.CategoriaId).IsRequired();

        }
    }
}