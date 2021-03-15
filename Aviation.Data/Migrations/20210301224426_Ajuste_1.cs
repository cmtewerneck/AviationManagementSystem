using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class Ajuste_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TempoVoo",
                table: "Voos_Instrucao",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TempoVoo",
                table: "Voos_Instrucao",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
