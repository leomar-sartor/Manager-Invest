using Microsoft.EntityFrameworkCore.Migrations;

namespace Carteira.Domain.Migrations
{
    public partial class CorrectClassAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoIvestimento",
                table: "Ativos");

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Operacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<short>(
                name: "TipoInvestimento",
                table: "Ativos",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Operacoes");

            migrationBuilder.DropColumn(
                name: "TipoInvestimento",
                table: "Ativos");

            migrationBuilder.AddColumn<short>(
                name: "TipoIvestimento",
                table: "Ativos",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }
    }
}
