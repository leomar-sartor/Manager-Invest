using Microsoft.EntityFrameworkCore.Migrations;

namespace Carteira.Domain.Migrations
{
    public partial class CustoMedio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Operacoes",
                newName: "PrecoUnitario");

            migrationBuilder.AddColumn<decimal>(
                name: "Corretagem",
                table: "Operacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CustoMedio",
                table: "Operacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Emolumentos",
                table: "Operacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Corretagem",
                table: "Operacoes");

            migrationBuilder.DropColumn(
                name: "CustoMedio",
                table: "Operacoes");

            migrationBuilder.DropColumn(
                name: "Emolumentos",
                table: "Operacoes");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "Operacoes",
                newName: "Preco");
        }
    }
}
