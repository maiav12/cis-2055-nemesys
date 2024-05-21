using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Data.Migrations
{
    /// <inheritdoc />
    public partial class StatusUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "471ddd6f-32ea-4e17-9d62-261fa6f87a84" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "471ddd6f-32ea-4e17-9d62-261fa6f87a84");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5e8165cb-313c-4e36-886c-88d32c78f6ea", 0, "9db8ec31-386a-4db1-b081-8e193db7501d", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAELQ4FjNo9j01LjydKHrTbzOGDleY+Hj9WZu71BK9u53et6mke1o+E1VtsriVcbHK2w==", "", false, "8742992a-9e99-4860-97a3-52436f0cd08a", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 5, 3, 8, 17, 37, 381, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 5, 3, 8, 17, 37, 381, DateTimeKind.Utc).AddTicks(3304), new DateTime(2024, 5, 3, 8, 17, 37, 381, DateTimeKind.Utc).AddTicks(3299) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "5e8165cb-313c-4e36-886c-88d32c78f6ea" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "5e8165cb-313c-4e36-886c-88d32c78f6ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e8165cb-313c-4e36-886c-88d32c78f6ea");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "471ddd6f-32ea-4e17-9d62-261fa6f87a84", 0, "f818d6cc-37e8-46cf-aee2-de2c8383a204", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEAJwaeG5phlLUy7Wkz66N6ZhloIu4mycUP6qlxhaPmx4Wk8NcqlHe3VBL9b1D5/PXA==", "", false, "c1684eac-7ef5-4ac2-a1be-a85e31f1b2fd", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 4, 29, 5, 26, 58, 117, DateTimeKind.Utc).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 4, 29, 5, 26, 58, 117, DateTimeKind.Utc).AddTicks(1058), new DateTime(2024, 4, 29, 5, 26, 58, 117, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "471ddd6f-32ea-4e17-9d62-261fa6f87a84" });
        }
    }
}
