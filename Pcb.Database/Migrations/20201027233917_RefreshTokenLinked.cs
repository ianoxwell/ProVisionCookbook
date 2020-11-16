using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class RefreshTokenLinked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.AddColumn<int>(
                name: "FailedLoginAttempt",
                schema: "sec",
                table: "User",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFailedLoginAttempt",
                schema: "sec",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "sec",
                table: "RefreshToken",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "(sysdatetimeoffset())");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "sec",
                table: "RefreshToken",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByIp",
                schema: "sec",
                table: "RefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Expires",
                schema: "sec",
                table: "RefreshToken",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ReplacedByToken",
                schema: "sec",
                table: "RefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Revoked",
                schema: "sec",
                table: "RefreshToken",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevokedByIp",
                schema: "sec",
                table: "RefreshToken",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                schema: "sec",
                table: "RefreshToken",
                columns: new[] { "UserId", "Id" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Wholemeal Flour");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Baby Spinach Leaves");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$Ie7FcxLUw91rkKwj65YQ/euyXLpMsRoTh1F1yf4L/IX2NwVQ6cdFG" });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User_UserId",
                schema: "sec",
                table: "RefreshToken",
                column: "UserId",
                principalSchema: "sec",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User_UserId",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "FailedLoginAttempt",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastFailedLoginAttempt",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "CreatedByIp",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Expires",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "ReplacedByToken",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "Revoked",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "RevokedByIp",
                schema: "sec",
                table: "RefreshToken");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "sec",
                table: "RefreshToken",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "(sysdatetimeoffset())",
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "sec",
                table: "RefreshToken",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                schema: "sec",
                table: "RefreshToken",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Wholemeal Flour");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Ingredient",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Baby Spinach Leaves");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$97X6/vEUsoqUfKctpk0aPeUnQ7V.dVLUpmsfl/IfYco1EbuTPucXu" });
        }
    }
}
