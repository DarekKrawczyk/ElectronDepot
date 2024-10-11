using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class _24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Components_Categories_CategoryID1",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Components_CategoryID1",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "CategoryID1",
                table: "Components");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID1",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_CategoryID1",
                table: "Components",
                column: "CategoryID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Categories_CategoryID1",
                table: "Components",
                column: "CategoryID1",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }
    }
}
