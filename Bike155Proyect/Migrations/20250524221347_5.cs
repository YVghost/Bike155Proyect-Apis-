using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bike155Proyect.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ruta_Bike_BikeId",
                table: "Ruta");

            migrationBuilder.DropForeignKey(
                name: "FK_Ruta_Users_UserId",
                table: "Ruta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ruta",
                table: "Ruta");

            migrationBuilder.RenameTable(
                name: "Ruta",
                newName: "Rutas");

            migrationBuilder.RenameIndex(
                name: "IX_Ruta_UserId",
                table: "Rutas",
                newName: "IX_Rutas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ruta_BikeId",
                table: "Rutas",
                newName: "IX_Rutas_BikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rutas",
                table: "Rutas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Bike_BikeId",
                table: "Rutas",
                column: "BikeId",
                principalTable: "Bike",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rutas_Users_UserId",
                table: "Rutas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Bike_BikeId",
                table: "Rutas");

            migrationBuilder.DropForeignKey(
                name: "FK_Rutas_Users_UserId",
                table: "Rutas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rutas",
                table: "Rutas");

            migrationBuilder.RenameTable(
                name: "Rutas",
                newName: "Ruta");

            migrationBuilder.RenameIndex(
                name: "IX_Rutas_UserId",
                table: "Ruta",
                newName: "IX_Ruta_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rutas_BikeId",
                table: "Ruta",
                newName: "IX_Ruta_BikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ruta",
                table: "Ruta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ruta_Bike_BikeId",
                table: "Ruta",
                column: "BikeId",
                principalTable: "Bike",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ruta_Users_UserId",
                table: "Ruta",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
