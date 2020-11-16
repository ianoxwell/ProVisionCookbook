using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class RawFoodsUSDACreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RawFoodUsda",
                nullable: false,
                defaultValueSql: "(sysdatetimeoffset())",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$5F1Gt5Zk382..OQ81hSB6.Tc4xEoSA.nhfK3PPcKeR5r7XgGVEU5O" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "dbo",
                table: "RawFoodUsda",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldDefaultValueSql: "(sysdatetimeoffset())");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "PasswordHash" },
                values: new object[] { "Admin@cookbook.com", "$2a$11$W6D9YmUUPZ/aWZlY5V5JuuCUHS2UMOFLH4JO4w1IWDqB5HODJ2Laa" });
        }
    }
}
