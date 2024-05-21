using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "32a4022a-6dce-4d0b-a465-01d5877a1173" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a4022a-6dce-4d0b-a465-01d5877a1173");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfReport",
                table: "NearMissReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTimeSpotted",
                table: "NearMissReports",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAction",
                table: "Investigations",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b4c9cfb-6d13-431b-8e9e-6841b37efe3b", 0, "fbd133e0-ef70-46f2-8046-e162e4fef6a1", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEIymnlgh46FLWxajn1Fe1oueCwMhDOIM7vzaJJqI/ixLHxb5K9FrsmIZnC/nF+GEcg==", "", false, "119b8e35-4eb8-4d2e-9715-f3fc3e8c1ce4", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 5, 14, 19, 17, 0, 391, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 5, 14, 19, 17, 0, 391, DateTimeKind.Utc).AddTicks(6145), new DateTime(2024, 5, 14, 19, 17, 0, 391, DateTimeKind.Utc).AddTicks(6139) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "0b4c9cfb-6d13-431b-8e9e-6841b37efe3b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "0b4c9cfb-6d13-431b-8e9e-6841b37efe3b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b4c9cfb-6d13-431b-8e9e-6841b37efe3b");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfReport",
                table: "NearMissReports",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTimeSpotted",
                table: "NearMissReports",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfAction",
                table: "Investigations",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32a4022a-6dce-4d0b-a465-01d5877a1173", 0, "2f13b26a-70f0-4990-96d1-40ee390ba225", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEL2OD+3uLOdyLbruilXPPkyV6BFbcEdQGKnVWqkw5Rw7f0vFK0RY6EUNWz9utJYmmA==", "", false, "76f816ef-10af-46d1-8eb6-5c2f3c7b41f8", false, "admin@mail.com" });

            migrationBuilder.UpdateData(
                table: "Investigations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfAction",
                value: new DateTime(2024, 5, 14, 18, 22, 29, 336, DateTimeKind.Utc).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "NearMissReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAndTimeSpotted", "DateOfReport" },
                values: new object[] { new DateTime(2024, 5, 14, 18, 22, 29, 336, DateTimeKind.Utc).AddTicks(8342), new DateTime(2024, 5, 14, 18, 22, 29, 336, DateTimeKind.Utc).AddTicks(8336) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "32a4022a-6dce-4d0b-a465-01d5877a1173" });
        }
    }
}
