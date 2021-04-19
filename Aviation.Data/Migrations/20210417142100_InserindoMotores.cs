using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class InserindoMotores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModeloMotor",
                table: "Aeronaves");

            migrationBuilder.DropColumn(
                name: "Motor",
                table: "Aeronaves");

            migrationBuilder.DropColumn(
                name: "NumeroSerieMotor",
                table: "Aeronaves");

            migrationBuilder.CreateTable(
                name: "Aeronaves_Motores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NumeroSerie = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    HorasTotais = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CiclosTotais = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AeronaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronaves_Motores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aeronaves_Motores_Aeronaves_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aeronaves_Motores_AeronaveId",
                table: "Aeronaves_Motores",
                column: "AeronaveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeronaves_Motores");

            migrationBuilder.AddColumn<string>(
                name: "ModeloMotor",
                table: "Aeronaves",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motor",
                table: "Aeronaves",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroSerieMotor",
                table: "Aeronaves",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
