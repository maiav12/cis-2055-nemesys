using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 4, 22, 14, 43, 26, 119, DateTimeKind.Utc).AddTicks(8909));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 4, 22, 14, 43, 26, 119, DateTimeKind.Utc).AddTicks(8114), new DateTime(2024, 4, 22, 14, 43, 26, 119, DateTimeKind.Utc).AddTicks(8109) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 4, 22, 13, 9, 31, 394, DateTimeKind.Utc).AddTicks(3331));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 4, 22, 13, 9, 31, 394, DateTimeKind.Utc).AddTicks(2935), new DateTime(2024, 4, 22, 13, 9, 31, 394, DateTimeKind.Utc).AddTicks(2931) });
        }
    }
}
