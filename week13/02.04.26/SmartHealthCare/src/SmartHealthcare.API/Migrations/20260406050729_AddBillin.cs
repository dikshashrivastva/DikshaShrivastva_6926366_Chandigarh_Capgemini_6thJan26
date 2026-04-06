using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHealthcare.API.Migrations
{
    /// <inheritdoc />
    public partial class AddBillin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 6, 5, 7, 28, 665, DateTimeKind.Utc).AddTicks(245), "$2a$11$ihcbA4xgEYTPrZxQgX7BRuDMALQuHjYm1jdMHurtbETElxOJA2GIO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 4, 6, 5, 6, 16, 50, DateTimeKind.Utc).AddTicks(6591), "$2a$11$41brD307pe95ICYJB.UCse9jZx.ZMZkGCjjdOIWNOTG4DpNdriN2O" });
        }
    }
}
