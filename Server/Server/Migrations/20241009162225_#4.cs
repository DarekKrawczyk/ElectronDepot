using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Purchase");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedDate",
                table: "Purchase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Purchase",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasedDate",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Purchase");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Purchase",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Purchase",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");
        }
    }
}
