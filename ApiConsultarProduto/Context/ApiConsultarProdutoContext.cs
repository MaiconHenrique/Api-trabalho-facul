using ApiConsultarProduto.Context.Maps;
using ApiConsultarProduto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiConsultarProduto.Context
{
    public class ApiConsultarProdutoContext : DbContext
    {
        public ApiConsultarProdutoContext(DbContextOptions<ApiConsultarProdutoContext> options): 
            base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
