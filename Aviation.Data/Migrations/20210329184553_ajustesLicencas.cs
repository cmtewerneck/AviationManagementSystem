using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class ajustesLicencas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licencas_Habilitacoes_Colaboradores_InstrutorId",
                table: "Licencas_Habilitacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Licencas_Habilitacoes_Colaboradores_TripulanteId",
                table: "Licencas_Habilitacoes");

            migrationBuilder.DropIndex(
                name: "IX_Licencas_Habilitacoes_InstrutorId",
                table: "Licencas_Habilitacoes");

            migrationBuilder.DropColumn(
                name: "InstrutorId",
                table: "Licencas_Habilitacoes");

            migrationBuilder.RenameColumn(
                name: "TripulanteId",
                table: "Licencas_Habilitacoes",
                newName: "ColaboradorId");

            migrationBuilder.RenameIndex(
                name: "IX_Licencas_Habilitacoes_TripulanteId",
                table: "Licencas_Habilitacoes",
                newName: "IX_Licencas_Habilitacoes_ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licencas_Habilitacoes_Colaboradores_ColaboradorId",
                table: "Licencas_Habilitacoes",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licencas_Habilitacoes_Colaboradores_ColaboradorId",
                table: "Licencas_Habilitacoes");

            migrationBuilder.RenameColumn(
                name: "ColaboradorId",
                table: "Licencas_Habilitacoes",
                newName: "TripulanteId");

            migrationBuilder.RenameIndex(
                name: "IX_Licencas_Habilitacoes_ColaboradorId",
                table: "Licencas_Habilitacoes",
                newName: "IX_Licencas_Habilitacoes_TripulanteId");

            migrationBuilder.AddColumn<Guid>(
                name: "InstrutorId",
                table: "Licencas_Habilitacoes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Licencas_Habilitacoes_InstrutorId",
                table: "Licencas_Habilitacoes",
                column: "InstrutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Licencas_Habilitacoes_Colaboradores_InstrutorId",
                table: "Licencas_Habilitacoes",
                column: "InstrutorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Licencas_Habilitacoes_Colaboradores_TripulanteId",
                table: "Licencas_Habilitacoes",
                column: "TripulanteId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
