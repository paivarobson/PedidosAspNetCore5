using Microsoft.EntityFrameworkCore;

namespace PedidosAspNetCore5.Models
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options)
            : base(options)
        { }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fornecedor
            modelBuilder.Entity<Fornecedor>()
                .HasKey(f => f.FornecedorId);

            modelBuilder.Entity<Fornecedor>()
                .Property(p => p.FornecedorId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Fornecedor>()
                .Property(i => i.RazaoSocial)
                .HasMaxLength(200);

            // Produto
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.ProdutoId);

            modelBuilder.Entity<Produto>()
                .Property(p => p.ProdutoId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Produto>()
                .Property(i => i.Descricao)
                .HasMaxLength(200);

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");

            // Pedido
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.PedidoId);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.PedidoId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pedido>()
               .HasOne(f => f.Fornecedor)
               .WithMany(p => p.Pedidos)
               .HasForeignKey(p => p.FornecedorId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>()
                .HasMany(i => i.Itens)
                .WithOne(p => p.Pedido)
                .HasForeignKey(ip => ip.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            // ItemPedido
            modelBuilder.Entity<ItemPedido>()
                .HasKey(p => p.PedidoId);

            modelBuilder.Entity<ItemPedido>()
                .Property(p => p.PrecoUnitario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemPedido>()
                .Property(p => p.ValorTotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
