using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class RemovendoCamposAeronaveDocumentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VencimentoCA",
                table: "Aeronaves");

            migrationBuilder.DropColumn(
                name: "VencimentoCM",
                table: "Aeronaves");

            migrationBuilder.DropColumn(
                name: "VencimentoCVA",
                table: "Aeronaves");

            migrationBuilder.DropColumn(
                name: "VencimentoCasco",
                table: "Aeronaves");

            migrationBuilder.DropColumn(
                name: "VencimentoReta",
                table: "Aeronaves");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VencimentoCA",
                table: "Aeronaves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VencimentoCM",
                table: "Aeronaves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VencimentoCVA",
                table: "Aeronaves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VencimentoCasco",
                table: "Aeronaves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VencimentoReta",
                table: "Aeronaves",
                type: "datetime2",
                nullable: true);
        }
    }
}
