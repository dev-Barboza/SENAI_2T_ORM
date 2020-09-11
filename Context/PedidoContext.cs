using EntityFramework.Domains;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Context
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-V0C9ELT0\SQLEXPRESS;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
