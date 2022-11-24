using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Povio.FlowerSpot.Persistence.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "CreatedDate", "Email", "Password", "Username" },
                values: new object[] { 1, new DateTime(2022, 11, 24, 13, 16, 41, 317, DateTimeKind.Utc).AddTicks(1137), "test@test.com", "test", "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
