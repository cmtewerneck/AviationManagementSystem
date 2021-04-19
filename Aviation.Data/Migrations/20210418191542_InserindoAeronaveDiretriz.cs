using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class InserindoAeronaveDiretriz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronaves_Diretrizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Referencia = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataEfetivacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    TipoDiretriz = table.Column<int>(type: "int", nullable: false),
                    IntervaloHoras = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IntervaloCiclos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IntervaloDias = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UltimoCuprimentoHoras = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UltimoCuprimentoCiclos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UltimoCuprimentoData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observacoes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronaves_Diretrizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aeronaves_Diretrizes_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aeronaves_Diretrizes_AeronaveId",
                table: "Aeronaves_Diretrizes",
                column: "AeronaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeronaves_Diretrizes");
        }
    }
}
