using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class AjustesInserindoSituacaoAlunoELicencaHabilitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SituacaoAluno",
                table: "Alunos_Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Licencas_Habilitacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripulanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InstrutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencas_Habilitacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licencas_Habilitacoes_Colaboradores_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Licencas_Habilitacoes_Colaboradores_TripulanteId",
                        column: x => x.TripulanteId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_Habilitacoes_InstrutorId",
                table: "Licencas_Habilitacoes",
                column: "InstrutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_Habilitacoes_TripulanteId",
                table: "Licencas_Habilitacoes",
                column: "TripulanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licencas_Habilitacoes");

            migrationBuilder.DropColumn(
                name: "SituacaoAluno",
                table: "Alunos_Turmas");
        }
    }
}
