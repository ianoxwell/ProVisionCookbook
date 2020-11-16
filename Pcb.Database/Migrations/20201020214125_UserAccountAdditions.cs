using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class UserAccountAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmailVerified",
                schema: "sec",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordReset",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResetToken",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpires",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Verified",
                schema: "sec",
                table: "User",
                nullable: true);

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "School",
                columns: new[] { "Id", "Address", "BusinessContactName", "Code", "EmailAddress", "EndDate", "PhoneNumber", "PostCode", "ShortName", "SortOrder", "StartDate", "StreetNumber", "Suburb", "Title" },
                values: new object[,]
                {
                    { 1, null, null, "NAS", null, null, null, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Not a School" },
                    { 2, null, null, "DEFAULT", null, null, null, "0000", null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Australia", "Default School" },
                    { 3, "18 Strathmore Parkway", "Paul Murphy", "HCC2020", "paul.murphy@hcc.wa.edu.au", null, null, "6030", "HCC", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ellenbrook", "Holy Cross College" }
                });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash", "Verified" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$97X6/vEUsoqUfKctpk0aPeUnQ7V.dVLUpmsfl/IfYco1EbuTPucXu", new DateTime(2018, 10, 10, 10, 10, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "School",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "School",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "School",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PasswordReset",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResetToken",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpires",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Updated",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Verified",
                schema: "sec",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailVerified",
                schema: "sec",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "EmailAddress", "IsEmailVerified" },
                values: new object[] { "Admin@cookbook.com", true });
        }
    }
}
