using ApiConsultarProduto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConsultarProduto.Context.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_produto");

            builder.Property(x => x.CodigoDeBarras)
                .HasColumnName("cb_produto");

            builder.Property(x => x.Descricao)
                .HasColumnName("dc_produto");

            builder.Property(x => x.Nome)
             .HasColumnName("nm_produto");
        }
    }
}
