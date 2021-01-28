using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class AltTitleFoodGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AltTitle",
                schema: "ref",
                table: "IngredientFoodGroup",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 9,
                column: "AltTitle",
                value: "Oil, Vinegar, Salad Dressing");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 12,
                column: "AltTitle",
                value: "Pasta and Rice");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 19,
                column: "AltTitle",
                value: "Condiments");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 20,
                column: "AltTitle",
                value: "Spices and Seasonings");

            migrationBuilder.UpdateData(
                schema: "ref",
                table: "IngredientFoodGroup",
                keyColumn: "Id",
                keyValue: 22,
                column: "AltTitle",
                value: "Produce");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$mp.ed40Nt4LTHqj9J12xyementoLs4m08dYSMin297Ecg6OFEvvdi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltTitle",
                schema: "ref",
                table: "IngredientFoodGroup");

            migrationBuilder.UpdateData(
                schema: "sec",
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$0gkWApUZYpUIRI/EyOHWa.lQBH/tK0Ij4t3pmOQAX1IDUGm0I7eaG");
        }
    }
}
