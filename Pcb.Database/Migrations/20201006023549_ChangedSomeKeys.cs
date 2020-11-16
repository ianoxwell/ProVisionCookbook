using Microsoft.EntityFrameworkCore.Migrations;

namespace Pcb.Database.Migrations
{
    public partial class ChangedSomeKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_IngredientState_IngredientStateId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_MeasurementUnit_MeasurementUnitId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_IngredientStateId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_MeasurementUnitId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "IngredientStateId",
                schema: "dbo",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "MeasurementUnitId",
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
                name: "IngredientStateId",
                schema: "dbo",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementUnitId",
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
                name: "IX_Recipe_IngredientStateId",
                schema: "dbo",
                table: "Recipe",
                column: "IngredientStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_MeasurementUnitId",
                schema: "dbo",
                table: "Recipe",
                column: "MeasurementUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_IngredientState_IngredientStateId",
                schema: "dbo",
                table: "Recipe",
                column: "IngredientStateId",
                principalSchema: "ref",
                principalTable: "IngredientState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_MeasurementUnit_MeasurementUnitId",
                schema: "dbo",
                table: "Recipe",
                column: "MeasurementUnitId",
                principalSchema: "ref",
                principalTable: "MeasurementUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
