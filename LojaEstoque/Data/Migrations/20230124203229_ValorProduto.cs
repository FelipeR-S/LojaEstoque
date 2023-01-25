using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaEstoque.Data.Migrations
{
    public partial class ValorProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Produto");
        }
    }
}
