using Microsoft.EntityFrameworkCore.Migrations;

namespace PedidosAspNetCore5.Migrations
{
    public partial class CriacaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailContato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeContato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataCadastro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FornecedorId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdItem = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItens",
                columns: table => new
                {
                    PedidoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItens", x => x.PedidoItemId);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "FornecedorId", "CNPJ", "EmailContato", "NomeContato", "RazaoSocial", "UF" },
                values: new object[,]
                {
                    { 1, "04386272000122", "administracao@franciscoeoliverentulhosltda.com.br", "Oliver", "Francisco e Oliver Entulhos Ltda", "CE" },
                    { 2, "29783701000126", "estoque@josefaefabioadvocaciame.com.br", "Josefa", "Josefa e Fábio Advocacia ME", "CE" },
                    { 3, "62777062000161", "contato@mirellaecalebevidrosme.com.br", "Mirella", "Mirella e Calebe Vidros ME", "CE" },
                    { 4, "00956073000151", "contabil@julioeosvaldoesportesltda.com.br", "Julio", "Julio e Osvaldo Esportes Ltda", "CE" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "DataCadastro", "Descricao", "Preco" },
                values: new object[,]
                {
                    { 1, "14/06/2021", "Maça", 5.99m },
                    { 2, "14/06/2021", "Banana", 4.99m },
                    { 3, "14/06/2021", "Melão", 5.99m },
                    { 4, "14/06/2021", "Laranja", 8.99m }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "PedidoId", "DataCadastro", "FornecedorId", "QtdItem", "Valor" },
                values: new object[] { 1, "14/06/2021", 1, 2, 10.98m });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "PedidoId", "DataCadastro", "FornecedorId", "QtdItem", "Valor" },
                values: new object[] { 2, "14/06/2021", 1, 1, 4.99m });

            migrationBuilder.InsertData(
                table: "PedidoItens",
                columns: new[] { "PedidoItemId", "PedidoId", "PrecoUnitario", "ProdutoId" },
                values: new object[] { 1, 1, 4.99m, 2 });

            migrationBuilder.InsertData(
                table: "PedidoItens",
                columns: new[] { "PedidoItemId", "PedidoId", "PrecoUnitario", "ProdutoId" },
                values: new object[] { 2, 1, 5.99m, 1 });

            migrationBuilder.InsertData(
                table: "PedidoItens",
                columns: new[] { "PedidoItemId", "PedidoId", "PrecoUnitario", "ProdutoId" },
                values: new object[] { 3, 2, 4.99m, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_PedidoId",
                table: "PedidoItens",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItens_ProdutoId",
                table: "PedidoItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FornecedorId",
                table: "Pedidos",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItens");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
