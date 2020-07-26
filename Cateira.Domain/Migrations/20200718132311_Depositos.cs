using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carteira.Domain.Migrations
{
    public partial class Depositos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoAcumulado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CorretoraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Depositos_Corretoras_CorretoraId",
                        column: x => x.CorretoraId,
                        principalTable: "Corretoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_CorretoraId",
                table: "Depositos",
                column: "CorretoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depositos");
        }
    }
}
