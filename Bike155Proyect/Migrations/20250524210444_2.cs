using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bike155Proyect.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bike_User_UserId",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Ruta");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Ruta",
                newName: "Ubicacion");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Ruta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Ruta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bike",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Ruta_UserId",
                table: "Ruta",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_User_UserId",
                table: "Bike",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ruta_User_UserId",
                table: "Ruta",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bike_User_UserId",
                table: "Bike");

            migrationBuilder.DropForeignKey(
                name: "FK_Ruta_User_UserId",
                table: "Ruta");

            migrationBuilder.DropIndex(
                name: "IX_Ruta_UserId",
                table: "Ruta");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Ruta");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ruta");

            migrationBuilder.RenameColumn(
                name: "Ubicacion",
                table: "Ruta",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Ruta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bike",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_User_UserId",
                table: "Bike",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
