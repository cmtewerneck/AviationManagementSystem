using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class AdicionandoMensalidadeInscricaoTUrma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Inscricao",
                table: "Turmas",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Mensalidade",
                table: "Turmas",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inscricao",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Mensalidade",
                table: "Turmas");
        }
    }
}
