using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class _28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents");

            migrationBuilder.AlterColumn<int>(
                name: "ComponentID",
                table: "ProjectComponents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Components",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Components",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents",
                column: "ComponentID",
                principalTable: "Components",
                principalColumn: "ComponentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents");

            migrationBuilder.AlterColumn<int>(
                name: "ComponentID",
                table: "ProjectComponents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Components",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Components",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Categories_CategoryID",
                table: "Components",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents",
                column: "ComponentID",
                principalTable: "Components",
                principalColumn: "ComponentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
