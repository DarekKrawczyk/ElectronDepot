using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComponentID",
                table: "PurchaseItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentID);
                    table.ForeignKey(
                        name: "FK_Components_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ComponentID",
                table: "PurchaseItems",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_Components_CategoryID",
                table: "Components",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Components_ComponentID",
                table: "PurchaseItems",
                column: "ComponentID",
                principalTable: "Components",
                principalColumn: "ComponentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Components_ComponentID",
                table: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_ComponentID",
                table: "PurchaseItems");

            migrationBuilder.DropColumn(
                name: "ComponentID",
                table: "PurchaseItems");
        }
    }
}
