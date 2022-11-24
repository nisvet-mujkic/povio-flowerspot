using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Povio.FlowerSpot.Persistence.Migrations
{
    public partial class AddQuoteToSighting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "Sighting",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 24, 14, 50, 25, 602, DateTimeKind.Utc).AddTicks(7091));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quote",
                table: "Sighting");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 24, 13, 16, 41, 317, DateTimeKind.Utc).AddTicks(1137));
        }
    }
}
