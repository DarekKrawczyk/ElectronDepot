using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class _31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents");


            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents",
                column: "ComponentID",
                principalTable: "Components",
                principalColumn: "ComponentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectComponents_Components_ComponentID",
                table: "ProjectComponents",
                column: "ComponentID",
                principalTable: "Components",
                principalColumn: "ComponentID");
        }
    }
}
