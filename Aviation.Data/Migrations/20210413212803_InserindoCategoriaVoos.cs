using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class InserindoCategoriaVoos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Voos_Agendados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Categorias_Voos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias_Voos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voos_Agendados_CategoriaId",
                table: "Voos_Agendados",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voos_Agendados_Categorias_Voos_CategoriaId",
                table: "Voos_Agendados",
                column: "CategoriaId",
                principalTable: "Categorias_Voos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voos_Agendados_Categorias_Voos_CategoriaId",
                table: "Voos_Agendados");

            migrationBuilder.DropTable(
                name: "Categorias_Voos");

            migrationBuilder.DropIndex(
                name: "IX_Voos_Agendados_CategoriaId",
                table: "Voos_Agendados");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Voos_Agendados");
        }
    }
}
