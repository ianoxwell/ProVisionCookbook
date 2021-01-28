using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class ExpandedReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "HealthLabel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "DishTag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 1,
                column: "AltTitle",
                value: "veryHealthy");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 2,
                column: "AltTitle",
                value: "cheap");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 3,
                column: "AltTitle",
                value: "veryPopular");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 4,
                column: "AltTitle",
                value: "sustainable");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "DishTag",
                keyColumn: "Id",
                keyValue: 5,
                column: "AltTitle",
                value: "complicated");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 1,
                column: "AltTitle",
                value: "vegetarian");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 3,
                column: "AltTitle",
                value: "vegan");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 4,
                column: "AltTitle",
                value: "glutenFree");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 5,
                column: "AltTitle",
                value: "dairyFree");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 6,
                column: "AltTitle",
                value: "lowFodmap");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 7,
                column: "AltTitle",
                value: "ketogenic");

            migrationBuilder.InsertData(
                schema: "ref",
                table: "HealthLabel",
                columns: new[] { "Id", "AltTitle", "Summary", "Symbol", "Title" },
                values: new object[] { 8, "whole30", "The Whole30 is a 30-day fad diet that emphasizes whole foods and the elimination of sugar, alcohol, grains, legumes, soy, and dairy. The Whole30 is similar to but more restrictive than the paleo diet, as adherents may not eat natural sweeteners like honey or maple syrup.", null, "Whole 30" });

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$0gkWApUZYpUIRI/EyOHWa.lQBH/tK0Ij4t3pmOQAX1IDUGm0I7eaG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "ref",
                table: "HealthLabel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "HealthLabel");

            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "DishTag");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$aTi1SUb4zAyRstOnWmqh8OmCQfhRQGpTPtDlgST8YGjlkvIYGHQ22");
        }
    }
}
