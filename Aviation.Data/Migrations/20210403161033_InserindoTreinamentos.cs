using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class InserindoTreinamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treinamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoTreinamento = table.Column<int>(type: "int", nullable: false),
                    ClassificacaoTreinamento = table.Column<int>(type: "int", nullable: false),
                    TipoClasse = table.Column<int>(type: "int", nullable: false),
                    ModeloAeronave = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Instrutor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TripulanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treinamentos_Colaboradores_TripulanteId",
                        column: x => x.TripulanteId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treinamentos_TripulanteId",
                table: "Treinamentos",
                column: "TripulanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Treinamentos");
        }
    }
}
