using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class AltTitleMissedOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientFoodGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$S4dxbyF50IGHihuLuY5WIuvkWZTnHLJhrGOEOhhrzqFbYYeCtdKai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnlineId",
                schema: "ref",
                table: "IngredientFoodGroup");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$TS8dKgDnLbQ8f8768.JwVediNbIbU00vWaoAaCIpdVFzC/Ve2eLTa");
        }
    }
}
