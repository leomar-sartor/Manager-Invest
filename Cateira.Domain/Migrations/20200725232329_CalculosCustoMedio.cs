using Microsoft.EntityFrameworkCore.Migrations;

namespace Carteira.Domain.Migrations
{
    public partial class CalculosCustoMedio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SaldoCotas",
                table: "Operacoes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaldoCotas",
                table: "Operacoes");
        }
    }
}
