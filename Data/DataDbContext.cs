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
        public DbSet<PedidoItem> PedidoItens { get; set; }
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

            // Fornecedor :: Poupulando dados
            modelBuilder.Entity<Fornecedor>()
            .HasData(new Fornecedor
            {
                FornecedorId = 1,
                CNPJ = "04386272000122",
                RazaoSocial = "Francisco e Oliver Entulhos Ltda",
                UF = "CE",
                EmailContato = "administracao@franciscoeoliverentulhosltda.com.br",
                NomeContato = "Oliver"
            });

            modelBuilder.Entity<Fornecedor>()
            .HasData(new Fornecedor
            {
                FornecedorId = 2,
                CNPJ = "29783701000126",
                RazaoSocial = "Josefa e Fábio Advocacia ME",
                UF = "CE",
                EmailContato = "estoque@josefaefabioadvocaciame.com.br",
                NomeContato = "Josefa"
            });

            modelBuilder.Entity<Fornecedor>()
            .HasData(new Fornecedor
            {
                FornecedorId = 3,
                CNPJ = "62777062000161",
                RazaoSocial = "Mirella e Calebe Vidros ME",
                UF = "CE",
                EmailContato = "contato@mirellaecalebevidrosme.com.br",
                NomeContato = "Mirella"
            });

            modelBuilder.Entity<Fornecedor>()
            .HasData(new Fornecedor
            {
                FornecedorId = 4,
                CNPJ = "00956073000151",
                RazaoSocial = "Julio e Osvaldo Esportes Ltda",
                UF = "CE",
                EmailContato = "contabil@julioeosvaldoesportesltda.com.br",
                NomeContato = "Julio"
            });

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

            // Produto :: Poupulando dados
            modelBuilder.Entity<Produto>()
            .HasData(new Produto
            {
                ProdutoId = 1,
                Descricao = "Maça",
                DataCadastro = "14/06/2021",
                Preco = 5.99
            });

            modelBuilder.Entity<Produto>()
            .HasData(new Produto
            {
                ProdutoId = 2,
                Descricao = "Banana",
                DataCadastro = "14/06/2021",
                Preco = 4.99
            });

            modelBuilder.Entity<Produto>()
            .HasData(new Produto
            {
                ProdutoId = 3,
                Descricao = "Melão",
                DataCadastro = "14/06/2021",
                Preco = 5.99
            });

            modelBuilder.Entity<Produto>()
            .HasData(new Produto
            {
                ProdutoId = 4,
                Descricao = "Laranja",
                DataCadastro = "14/06/2021",
                Preco = 8.99
            });

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

            // Pedido :: Poupulando dados
            modelBuilder.Entity<Pedido>()
            .HasData(new Pedido
            {
                PedidoId = 1,
                FornecedorId = 1,
                DataCadastro = "14/06/2021",
                QtdItem = 2,
                Valor = 10.98
            });

            modelBuilder.Entity<Pedido>()
            .HasData(new Pedido
            {
                PedidoId = 2,
                FornecedorId = 1,
                DataCadastro = "14/06/2021",
                QtdItem = 1,
                Valor = 4.99
            });

            // PedidoItem
            modelBuilder.Entity<PedidoItem>()
                    .Property(p => p.PrecoUnitario)
                    .HasColumnType("decimal(18,2)");

            // PedidoItem :: Poupulando dados
            modelBuilder.Entity<PedidoItem>()
            .HasData(new PedidoItem
            {
                PedidoItemId = 1,
                PedidoId = 1,
                ProdutoId = 2,
                PrecoUnitario = 4.99
            });

            modelBuilder.Entity<PedidoItem>()
            .HasData(new PedidoItem
            {
                PedidoItemId = 2,
                PedidoId = 1,
                ProdutoId = 1,
                PrecoUnitario = 5.99
            });

            modelBuilder.Entity<PedidoItem>()
            .HasData(new PedidoItem
            {
                PedidoItemId = 3,
                PedidoId = 2,
                ProdutoId = 2,
                PrecoUnitario = 4.99
            });
        }
    }
}
