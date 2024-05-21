using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nemesys.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvestigationSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NearMissReportId1",
                table: "Investigations",
                type: "int",
                nullable: true);

            migrationBuilder.DropIndex(
                name: "IX_Investigations_NearMissReportId",
                table: "Investigations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "64a898d0-84e7-4fa4-af01-18fdb62495f0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64a898d0-84e7-4fa4-af01-18fdb62495f0");

            migrationBuilder.Sql("UPDATE Investigations SET DateOfAction = GETUTCDATE() WHERE Id = 1");
            migrationBuilder.Sql("UPDATE NearMissReports SET DateAndTimeSpotted = GETUTCDATE(), DateOfReport = GETUTCDATE() WHERE Id = 1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32a4022a-6dce-4d0b-a465-01d5877a1173", 0, "2f13b26a-70f0-4990-96d1-40ee390ba225", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEL2OD+3uLOdyLbruilXPPkyV6BFbcEdQGKnVWqkw5Rw7f0vFK0RY6EUNWz9utJYmmA==", "", false, "76f816ef-10af-46d1-8eb6-5c2f3c7b41f8", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NearMissReportId1",
                table: "Investigations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "32a4022a-6dce-4d0b-a465-01d5877a1173" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32a4022a-6dce-4d0b-a465-01d5877a1173");

            migrationBuilder.Sql("UPDATE Investigations SET DateOfAction = GETUTCDATE() WHERE Id = 1");
            migrationBuilder.Sql("UPDATE NearMissReports SET DateAndTimeSpotted = GETUTCDATE(), DateOfReport = GETUTCDATE() WHERE Id = 1");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d234f58e-7373-4ee5-98f0-c17892784b05", "64a898d0-84e7-4fa4-af01-18fdb62495f0" });
        }
    }
}
