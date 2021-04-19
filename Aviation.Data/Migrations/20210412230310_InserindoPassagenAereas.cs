using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class InserindoPassagenAereas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passagens_Aereas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVoo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Empresa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Origem = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Destino = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FormaPagamento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Assento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Localizador = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    ColaboradorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagens_Aereas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passagens_Aereas_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagens_Aereas_ColaboradorId",
                table: "Passagens_Aereas",
                column: "ColaboradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagens_Aereas");
        }
    }
}
