using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bike155Proyect.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bike_User_UserId",
                table: "Bike");

            migrationBuilder.DropIndex(
                name: "IX_Bike_UserId",
                table: "Bike");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bike");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bike",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bike_UserId",
                table: "Bike",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bike_User_UserId",
                table: "Bike",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
