using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AviationManagementSystem.Data.Migrations
{
    public partial class InserindoCategoriasTreinamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModeloAeronave",
                table: "Treinamentos",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CargaHoraria",
                table: "Treinamentos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Treinamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Treinamentos",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Categorias_Treinamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias_Treinamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treinamentos_CategoriaId",
                table: "Treinamentos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treinamentos_Categorias_Treinamentos_CategoriaId",
                table: "Treinamentos",
                column: "CategoriaId",
                principalTable: "Categorias_Treinamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treinamentos_Categorias_Treinamentos_CategoriaId",
                table: "Treinamentos");

            migrationBuilder.DropTable(
                name: "Categorias_Treinamentos");

            migrationBuilder.DropIndex(
                name: "IX_Treinamentos_CategoriaId",
                table: "Treinamentos");

            migrationBuilder.DropColumn(
                name: "CargaHoraria",
                table: "Treinamentos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Treinamentos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Treinamentos");

            migrationBuilder.AlterColumn<string>(
                name: "ModeloAeronave",
                table: "Treinamentos",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);
        }
    }
}
