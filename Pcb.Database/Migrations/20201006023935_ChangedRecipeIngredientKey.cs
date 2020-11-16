using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class ChangedRecipeIngredientKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_IngredientId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                schema: "dbo",
                table: "Recipe");

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
            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                schema: "dbo",
                table: "Recipe",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IngredientId",
                schema: "dbo",
                table: "Recipe",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Ingredient_IngredientId",
                schema: "dbo",
                table: "Recipe",
                column: "IngredientId",
                principalSchema: "dbo",
                principalTable: "Ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
