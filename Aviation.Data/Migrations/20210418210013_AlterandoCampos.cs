using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class AlterandoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimoCuprimentoHoras",
                table: "Aeronaves_Diretrizes",
                newName: "UltimoCumprimentoHoras");

            migrationBuilder.RenameColumn(
                name: "UltimoCuprimentoData",
                table: "Aeronaves_Diretrizes",
                newName: "UltimoCumprimentoData");

            migrationBuilder.RenameColumn(
                name: "UltimoCuprimentoCiclos",
                table: "Aeronaves_Diretrizes",
                newName: "UltimoCumprimentoCiclos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimoCumprimentoHoras",
                table: "Aeronaves_Diretrizes",
                newName: "UltimoCuprimentoHoras");

            migrationBuilder.RenameColumn(
                name: "UltimoCumprimentoData",
                table: "Aeronaves_Diretrizes",
                newName: "UltimoCuprimentoData");

            migrationBuilder.RenameColumn(
                name: "UltimoCumprimentoCiclos",
                table: "Aeronaves_Diretrizes",
                newName: "UltimoCuprimentoCiclos");
        }
    }
}
