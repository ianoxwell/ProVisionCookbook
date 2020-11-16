using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class AdditionalFieldsUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
                schema: "dbo",
                table: "RecipePicture");

            migrationBuilder.AddColumn<string>(
                name: "LoginProvider",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoginProviderId",
                schema: "sec",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
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

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmailAddress",
                value: "Admin@cookbook.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginProvider",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LoginProviderId",
                schema: "sec",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                schema: "sec",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementUnitId",
                schema: "dbo",
                table: "RecipePicture",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                column: "EmailAddress",
                value: "Admin@cookbook.com");
        }
    }
}
